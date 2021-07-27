namespace Es.PesquisaCep.Infrastructure.Implementation.Base
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            Sucesso = true;
        }

        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
    }
}
