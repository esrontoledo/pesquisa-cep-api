using Es.PesquisaCep.Domain.Entities;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Domain.Repositories.Interfaces
{
    public interface ICepRepository
    {
        Task<CepEntity> GetCepAsync(string cep);
    }
}
