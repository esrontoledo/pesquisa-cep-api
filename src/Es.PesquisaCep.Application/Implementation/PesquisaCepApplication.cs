using AutoMapper;
using Es.PesquisaCep.Application.Interfaces;
using Es.PesquisaCep.Application.Models;
using Es.PesquisaCep.Application.Result;
using Es.PesquisaCep.Domain.Repositories.Interfaces;
using Flunt.Notifications;
using System.Linq;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Application.Implementation
{
    public class PesquisaCepApplication : IPesquisaCepApplication
    {
        private readonly IMapper _mapper;
        private readonly ICepRepository _cepRepository;

        public PesquisaCepApplication(
            IMapper mapper,
            ICepRepository cepRepository)
        {
            _mapper = mapper;
            _cepRepository = cepRepository;
        }

        public async Task<Result<CepModel>> GetCepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep)) return GetResultErros("Cep", "Necessário informar o cep");
            if (!cep.All(char.IsDigit)) return GetResultErros("Cep", "Cep deve conter apenas números");

            var cepResult = _mapper.Map<CepModel>(await _cepRepository.GetCepAsync(cep));

            if (cepResult != null)
            {
                return Result<CepModel>.Ok(cepResult);
            }

            return GetResultErros("Erro", "Cep não encontrado");

        }

        private Result<CepModel> GetResultErros(string erro, string message) => Result<CepModel>.Error(new Notification(erro, message));
    }
}
