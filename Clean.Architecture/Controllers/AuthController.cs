using Clean.Architecture.Application.Interfaces.UseCases.AuthCases.Commands;
using Clean.Architecture.Contracts.AuthContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAuthenticationCommand _authenticationCommand;

        public AuthController(IAuthenticationCommand authenticationCommand)
        {
            _authenticationCommand = authenticationCommand;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(AuthRequest request)
        {
            var result = await _authenticationCommand.Execute(request);
            return result.IsSuccess ? Ok(result.GetValue()) : Problem(result.Error);
        }
    }
}
