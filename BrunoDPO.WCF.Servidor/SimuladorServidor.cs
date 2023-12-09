using BrunoDPO.WCF.Contratos.Entidades;
using BrunoDPO.WCF.Contratos.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BrunoDPO.WCF.Servidor
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class SimuladorServidor : IServidor
    {
        private const string PROTOCOLO = "net.tcp";
        private const int PRIMEIRA_PORTA = 50_500;
        private const int ULTIMA_PORTA = 65_535;
        private const int PING_MILLIS = 30_000;
        private const int TIMEOUT_PING_MILLIS = 1_000;

        private readonly NetTcpBinding _defaultBinding = new NetTcpBinding(SecurityMode.None, true);
        private readonly Dictionary<string, string> _clientes = new Dictionary<string, string>();
        private readonly Dictionary<string, int> _ultimaPortaServidor = new Dictionary<string, int>();
        private readonly ChannelFactory<ICliente> _factoryCliente;
        private readonly Timer _pingador = new Timer(PING_MILLIS);

        public SimuladorServidor()
        {
            _factoryCliente = new ChannelFactory<ICliente>(_defaultBinding);
            _pingador.Elapsed += Pingar;
            _pingador.Start();
        }

        public RespostaServidor ConectarCliente(RequisicaoCliente requisicao)
        {
            var chave = $"{requisicao.Origem}/{requisicao.Fila}";
            if (_clientes.ContainsKey(chave))
            {
                return new RespostaServidor(sucesso: true, mensagem: _clientes[chave]);
            }

            var chamador = ObterEnderecoChamador();

            if (!_ultimaPortaServidor.ContainsKey(chamador))
            {
                _ultimaPortaServidor.Add(chamador, PRIMEIRA_PORTA);
            }

            var porta = _ultimaPortaServidor[chamador];
            var uri = new Uri($"{PROTOCOLO}://{chamador}:{porta}/{requisicao.Origem}/{requisicao.Fila}");
            _clientes.Add(chave, uri.AbsoluteUri);
            _ultimaPortaServidor[chamador] = porta == ULTIMA_PORTA ? PRIMEIRA_PORTA : porta + 1;

            Console.WriteLine($"Sistema {requisicao.Origem} na fila {requisicao.Fila} deve ouvir em: {uri.AbsoluteUri}");
            return new RespostaServidor(sucesso: true, mensagem: uri.AbsoluteUri);
        }

        public RespostaServidor DesconectarCliente(RequisicaoCliente requisicao)
        {
            var chave = $"{requisicao.Origem}/{requisicao.Fila}";
            if (_clientes.ContainsKey(chave))
            {
                _clientes.Remove(chave);
            }
            Console.WriteLine($"Sistema {requisicao.Origem} na fila {requisicao.Fila} desconectado");
            return new RespostaServidor(sucesso: true, mensagem: "Sistema desconectado");
        }

        public RespostaServidor Ping(RequisicaoCliente requisicao)
        {
            Console.WriteLine($"Ping solicitado pelo sistema {requisicao.Origem}");
            return new RespostaServidor(sucesso: true, mensagem: "Pong");
        }

        public RespostaServidor EnviarMensagem(RequisicaoCliente requisicao)
        {
            Console.WriteLine($"Enviando mensagem {requisicao.Mensagem} do sistema {requisicao.Origem} para o sistema {requisicao.Destino} na fila {requisicao.Fila}");

            var chave = $"{requisicao.Destino}/{requisicao.Fila}";
            if (!_clientes.ContainsKey(chave))
            {
                var erro = $"Sistema {requisicao.Destino} para fila {requisicao.Fila} inexistente";
                Console.WriteLine(erro);
                return new RespostaServidor(sucesso: false, mensagemErro: erro);
            }

            var endpoint = new EndpointAddress(_clientes[chave]);
            var canalCliente = _factoryCliente.CreateChannel(endpoint);

            RespostaCliente resposta;
            try
            {
                resposta = canalCliente.ReceberMensagem(requisicao.Mensagem);
                Console.WriteLine($"Retorno do {requisicao.Destino}: Sucesso = {resposta.Sucesso} Mensagem de erro = {resposta.MensagemErro}");
            }
            catch (CommunicationException ex)
            {
                resposta = new RespostaCliente(sucesso: false, mensagemErro: ex.Message);
                Console.WriteLine($"Erro ao chamar {requisicao.Destino} na fila {requisicao.Fila}. Removendo da lista.");
                _clientes.Remove(chave);
            }

            return new RespostaServidor(sucesso: resposta.Sucesso, mensagemErro: resposta.MensagemErro);
        }

        private string ObterEnderecoChamador()
        {
            var contexto = OperationContext.Current;
            var propriedades = contexto.IncomingMessageProperties;
            var endpoint = propriedades[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            var endereco = IPAddress.Parse(endpoint.Address);
            if (endereco.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return Dns.GetHostEntry(endpoint.Address).HostName;
            }
            return endpoint.Address;
        }

        private void Pingar(object sender, ElapsedEventArgs e)
        {
            var timer = sender as Timer;
            timer.Stop();

            List<string> urlInvalidas = new List<string>();
            foreach (var chave in _clientes.Keys)
            {
                var enderecoCliente = _clientes[chave];
                var online = PingarCliente(enderecoCliente);
                if (online)
                {
                    Console.WriteLine($"Cliente {enderecoCliente} online");
                    continue;
                }
                urlInvalidas.Add(chave);
            }
            foreach (var url in urlInvalidas)
            {
                Console.WriteLine($"Apaga roteamento para {url}");
                _clientes.Remove(url);
            }
            timer.Start();
        }

        private bool PingarCliente(string enderecoCliente)
        {
            var endpoint = new EndpointAddress(enderecoCliente);
            var canalCliente = _factoryCliente.CreateChannel(endpoint);

            var pingTask = Task.Run(() =>
            {
                try
                {
                    canalCliente.Ping();
                }
                catch
                {
                    // Não faz nada
                }
            });
            pingTask.Wait(TIMEOUT_PING_MILLIS);
            if (pingTask.IsCompleted)
            {
                return true;
            }
            Console.WriteLine($"Timeout ao chamar {enderecoCliente}");
            return false;
        }

        private void DesconectarClientes()
        {
            Parallel.ForEach(_clientes.Values, new ParallelOptions { MaxDegreeOfParallelism = 5 }, cliente =>
            {
                var endpoint = new EndpointAddress(cliente);
                var canal = _factoryCliente.CreateChannel(endpoint);
                var taskDesconexao = Task.Run(() =>
                {
                    try
                    {
                        canal.Desconectar();
                    }
                    catch
                    {
                        // Ignora qualquer erro
                    }
                });
                taskDesconexao.Wait(TIMEOUT_PING_MILLIS);
            });
        }

        public void FinnalizarServidor()
        {
            _pingador.Stop();
            DesconectarClientes();
        }
    }
}
