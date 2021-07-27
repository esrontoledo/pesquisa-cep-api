using Es.PesquisaCep.Application.Models;

namespace Es.PesquisaCep.Application.Interfaces
{
    public interface ITokenApplication
    {
        string Generate(UserModel user);
    }
}
