using Es.PesquisaCep.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Api.Controllers
{
    [Route("pesquisas-cep")]
    public class PesquisaController : ControllerBase
    {
        private readonly IPesquisaCepApplication _pesquisaCepApplication;

        public PesquisaController(IPesquisaCepApplication pesquisaCepApplicatio)
        {
            _pesquisaCepApplication = pesquisaCepApplicatio;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> GetCepAsync(string cep)
        {
            var cepResult = await _pesquisaCepApplication.GetCepAsync(cep);

            if (cepResult.Success)
            {
                if (string.IsNullOrWhiteSpace(cepResult.Object?.Cep)) return NoContent();

                return Ok(cepResult.Object);
            }

            return BadRequest(cepResult.Notifications);
        }
    }
}
