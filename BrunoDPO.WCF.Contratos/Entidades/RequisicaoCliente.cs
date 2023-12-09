using System.Runtime.Serialization;

namespace BrunoDPO.WCF.Contratos.Entidades
{
    [DataContract]
    public class RequisicaoCliente
    {
        [DataMember]
        public string Origem { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public string Fila { get; set; }

        [DataMember]
        public string Mensagem { get; set; }
    }
}
