using Es.PesquisaCep.Domain.Entities;
using Es.PesquisaCep.Domain.Repositories.Interfaces;
using Es.PesquisaCep.DomainCore.Constantes;
using Es.PesquisaCep.DomainCore.Interfaces;
using Es.PesquisaCep.Infrastructure.Implementation.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Infrastructure.Implementation
{
    public class CepRepository : BaseApiRestRepository, ICepRepository
    {
        private readonly IEnviromentConfiguration _enviromentConfiguration;
        public CepRepository(
            IHttpClientFactory clientFactory,
            IEnviromentConfiguration enviromentConfiguration) : base(ParametroSistema.AmbienteCep, clientFactory)
        {
            _enviromentConfiguration = enviromentConfiguration;
        }

        public async Task<CepEntity> GetCepAsync(string cep)
        {
            return await GetAsync<CepEntity>($"ws/{cep}/json", null, null);
        }
    }
}
