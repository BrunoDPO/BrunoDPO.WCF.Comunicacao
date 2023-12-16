using BrunoDPO.WCF.Contratos.Entidades;
using BrunoDPO.WCF.Contratos.Interfaces;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrunoDPO.WCF.Cliente
{
    public partial class FormPrincipal : Form
    {
        private const string SERVIDOR_PROTOCOLO = "net.tcp";
        private const string SERVIDOR_ENDERECO_BASE = "localhost";
        private const int SERVIDOR_PORTA = 8_000;

        private readonly EndpointAddress _servidor = new EndpointAddress($"{SERVIDOR_PROTOCOLO}://{SERVIDOR_ENDERECO_BASE}:{SERVIDOR_PORTA}");
        private readonly NetTcpBinding _defaultBinding = new NetTcpBinding(SecurityMode.None, true);
        private readonly ChannelFactory<IServidor> _factoryServidor;
        private ServiceHost _hostCliente;

        public FormPrincipal()
        {
            _factoryServidor = new ChannelFactory<IServidor>(_defaultBinding, _servidor);
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var canalServidor = _factoryServidor.CreateChannel();
                var requisicao = new RequisicaoCliente() { Mensagem = "Ping" };
                var resposta = canalServidor.Ping(requisicao);
                MessageBox.Show($"Resposta do Servidor: {resposta.Mensagem}");
            });
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var canalServidor = _factoryServidor.CreateChannel();
                var requisicao = new RequisicaoCliente()
                {
                    Origem = txtOrigem.Text,
                    Destino = txtDestino.Text,
                    Fila = txtFilaEnvio.Text,
                    Mensagem = txtMensagemEnvio.Text
                };
                var resposta = canalServidor.EnviarMensagem(requisicao);
                if (!resposta.Sucesso)
                {
                    MessageBox.Show($"Resposta do Servidor: {resposta.MensagemErro}");
                }
            });
        }

        private async void btnConectarCliente_Click(object sender, EventArgs e)
        {
            btnConectarCliente.Enabled = false;
            btnConectarCliente.Visible = false;
            btnDesconectarCliente.Enabled = false;
            btnDesconectarCliente.Visible = true;

            var resposta = Task.Run(() =>
            {
                var canalServidor = _factoryServidor.CreateChannel();
                var requisicao = new RequisicaoCliente()
                {
                    Origem = txtSistema.Text,
                    Fila = txtFilaRecebimento.Text
                };
                return canalServidor.ConectarCliente(requisicao);
            });

            var endereco = (await resposta).Mensagem;
            txtMensagemRecebimento.Clear();
            txtMensagemRecebimento.AppendText($"Ouvindo em {endereco}{Environment.NewLine}");

            IniciarCliente(endereco);

            btnDesconectarCliente.Enabled = true;
        }

        private async void btnDesconectarCliente_Click(object sender, EventArgs e)
        {
            btnConectarCliente.Enabled = false;
            btnConectarCliente.Visible = true;
            btnDesconectarCliente.Enabled = false;
            btnDesconectarCliente.Visible = false;

            var resposta = Task.Run(() =>
            {
                var canalServidor = _factoryServidor.CreateChannel();
                var requisicao = new RequisicaoCliente()
                {
                    Origem = txtSistema.Text,
                    Fila = txtFilaRecebimento.Text
                };
                canalServidor.DesconectarCliente(requisicao);
            });
            await resposta;
            txtMensagemRecebimento.AppendText($"Cliente desconectado");

            btnConectarCliente.Enabled = true;
        }

        private void IniciarCliente(string endereco)
        {
            btnConectarCliente.Enabled = false;
            txtSistema.ReadOnly = true;
            txtFilaRecebimento.ReadOnly = true;

            var baseAddress = new Uri(endereco);
            _hostCliente = new ServiceHost(new SimuladorCliente(Escrever, Desconectar));
            _hostCliente.AddServiceEndpoint(typeof(ICliente), new NetTcpBinding(SecurityMode.None, true), baseAddress);
            _hostCliente.Open();
        }

        private async void Desconectar()
        {
            txtMensagemRecebimento.AppendText($"Desconexão solicitada pelo servidor{Environment.NewLine}");

            btnDesconectarCliente.Enabled = false;
            btnConectarCliente.Enabled = false;

            var resposta = Task.Run(() =>
            {
                if (_hostCliente != null)
                {
                    try
                    {
                        _hostCliente.Close();
                    }
                    catch
                    {
                        // Não faz nada
                    }
                    _hostCliente = null;
                }
            });
            await resposta;

            btnConectarCliente.Enabled = true;
            btnConectarCliente.Visible = true;
            btnDesconectarCliente.Visible = false;
            txtSistema.ReadOnly = false;
            txtFilaRecebimento.ReadOnly = false;

        }

        private void Escrever(string mensagem) =>
            txtMensagemRecebimento.AppendText($"{mensagem}{Environment.NewLine}");
    }
}
