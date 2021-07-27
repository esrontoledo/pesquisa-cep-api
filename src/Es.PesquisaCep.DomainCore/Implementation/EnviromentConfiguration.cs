using Es.PesquisaCep.DomainCore.Interfaces;
using System;

namespace Es.PesquisaCep.DomainCore.Implementation
{
    public class EnviromentConfiguration : IEnviromentConfiguration
    {
        public string Secret => Environment.GetEnvironmentVariable("SECRET");

        public string ConnectionString => Environment.GetEnvironmentVariable("CONNECTION_STRING");

        public string CepUrl => Environment.GetEnvironmentVariable("CEP_URL");
    }
}
