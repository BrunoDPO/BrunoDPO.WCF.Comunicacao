using BrunoDPO.WCF.Contratos.Entidades;
using System.ServiceModel;

namespace BrunoDPO.WCF.Contratos.Interfaces
{
    [ServiceContract]
    public interface ICliente
    {
        [OperationContract]
        void Desconectar();

        [OperationContract]
        RespostaCliente ReceberMensagem(string mensagem);

        [OperationContract]
        RespostaCliente Ping();
    }
}
