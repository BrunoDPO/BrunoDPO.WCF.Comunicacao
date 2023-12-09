using BrunoDPO.WCF.Contratos.Entidades;
using System.ServiceModel;

namespace BrunoDPO.WCF.Contratos.Interfaces
{
    [ServiceContract]
    public interface IServidor
    {
        [OperationContract]
        RespostaServidor ConectarCliente(RequisicaoCliente requisicao);

        [OperationContract]
        RespostaServidor DesconectarCliente(RequisicaoCliente requisicao);

        [OperationContract]
        RespostaServidor Ping(RequisicaoCliente requisicao);

        [OperationContract]
        RespostaServidor EnviarMensagem(RequisicaoCliente requisicao);
    }
}
