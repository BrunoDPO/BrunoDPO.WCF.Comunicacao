using System.Runtime.Serialization;

namespace BrunoDPO.WCF.Contratos.Entidades
{
    [DataContract]
    public class RespostaServidor
    {
        [DataMember]
        public bool Sucesso { get; set; }

        [DataMember]
        public string Mensagem { get; set; }

        [DataMember]
        public string MensagemErro { get; set; }

        public RespostaServidor(bool sucesso = default, string mensagem = default, string mensagemErro = default)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            MensagemErro = mensagemErro;
        }
    }
}
