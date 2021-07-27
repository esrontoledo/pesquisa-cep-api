using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Application.Result;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Application.Interfaces
{
    public interface IAccountApplication
    {
        Task<Result<UserModel>> LoginAsyc(string username, string password);
    }
}
