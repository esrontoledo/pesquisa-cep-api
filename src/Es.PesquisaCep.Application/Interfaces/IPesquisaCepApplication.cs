using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Application.Result;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Application.Interfaces
{
    public interface IPesquisaCepApplication
    {
        Task<Result<CepModel>> GetCepAsync(string cep);
    }
}
