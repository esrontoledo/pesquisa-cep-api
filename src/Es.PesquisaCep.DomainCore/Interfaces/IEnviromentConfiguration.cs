namespace Es.PesquisaCep.DomainCore.Interfaces
{
    public interface IEnviromentConfiguration
    {
        string Secret { get; }
        string ConnectionString { get; }
        string CepUrl { get; }
    }
}
