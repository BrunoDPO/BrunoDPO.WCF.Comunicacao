using BrunoDPO.WCF.Contratos.Entidades;
using BrunoDPO.WCF.Contratos.Interfaces;
using System;
using System.ServiceModel;

namespace BrunoDPO.WCF.Cliente
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class SimuladorCliente : ICliente
    {
        private readonly Action<string> _callbackNovaMensagem;
        private readonly Action _callbackDesconectar;

        public SimuladorCliente(Action<string> callbackNovaMensagem, Action callbackDesconectar)
        {
            _callbackNovaMensagem = callbackNovaMensagem;
            _callbackDesconectar = callbackDesconectar;
        }

        public void Desconectar()
        {
            _callbackDesconectar();
        }

        public RespostaCliente ReceberMensagem(string mensagem)
        {
            RespostaCliente resposta;
            try
            {
                _callbackNovaMensagem(mensagem);
                resposta = new RespostaCliente(sucesso: true);
            }
            catch (Exception exc)
            {
                resposta = new RespostaCliente(sucesso: false, mensagemErro: exc.Message);
            }
            return resposta;
        }

        public RespostaCliente Ping() =>
            new RespostaCliente(sucesso: true);
    }
}
