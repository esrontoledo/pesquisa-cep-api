using AutoMapper;
using Es.PesquisaCep.Application.Interfaces;
using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Application.Result;
using Es.PesquisaCep.Domain.Repositories.Interfaces;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Application.Implementation
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountApplication(
            IMapper mapper,
            IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<Result<UserModel>> LoginAsyc(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return GetResultErros("Erro", "Necessário informar o usuário");
            if (string.IsNullOrWhiteSpace(password)) return GetResultErros("Erro", "Necessário informar a senha");

            var user = _mapper.Map<UserModel>(await _accountRepository.LoginAsync(username, password));

            if (user == null)
            {
                return GetResultErros("Erro", "Usuário não encontrado");
            }

            return Result<UserModel>.Ok(user);
        }

        private Result<UserModel> GetResultErros(string erro, string message) => Result<UserModel>.Error(new Notification(erro, message));

    }
}
