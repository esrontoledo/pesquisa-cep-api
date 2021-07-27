using Es.PesquisaCep.Application.Interfaces;
using Es.PesquisaCep.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Api.Controllers
{
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenApplication _tokenApplication;
        private readonly IAccountApplication _accountApplication;

        public AccountController(
            ITokenApplication tokenApplication,
            IAccountApplication accountApplication)
        {
            _tokenApplication = tokenApplication;
            _accountApplication = accountApplication;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserModel model)
        {
            var userResult = await _accountApplication.LoginAsyc(model.Username, model.Password);

            if (userResult.Success)
            {
                var userModel = userResult.Object;
                var token = _tokenApplication.Generate(userModel);
                userModel.Password = "";
                return new
                {
                    user = userModel,
                    token = token
                };
            }

            return BadRequest(userResult.Notifications);
        }
    }
}
