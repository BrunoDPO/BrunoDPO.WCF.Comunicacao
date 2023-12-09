using System.Runtime.Serialization;

namespace BrunoDPO.WCF.Contratos.Entidades
{
    [DataContract]
    public class RespostaCliente
    {
        [DataMember]
        public bool Sucesso { get; set; }

        [DataMember]
        public string MensagemErro { get; set; }

        public RespostaCliente(bool sucesso = default, string mensagemErro = default)
        {
            Sucesso = sucesso;
            MensagemErro = mensagemErro;
        }
    }
}
