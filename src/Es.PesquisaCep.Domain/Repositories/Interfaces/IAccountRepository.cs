using Es.PesquisaCep.Domain.DbModel;
using Es.PesquisaCep.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Domain.Repositories.Interfaces
{
    public interface IAccountRepository : IBaseRepository<UserDbModel>
    {
        Task<UserDbModel> LoginAsync(string username, string password);
    }
}
