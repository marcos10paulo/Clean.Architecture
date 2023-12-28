using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Commands;
using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Queries;
using Clean.Architecture.Contracts.UserContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : BaseApiController
    {
        private readonly IUserCreateCommand _userCreateCommand;
        private readonly IUserGetByLoginQuery _userGetByLogin;

        public UserController(IUserCreateCommand userCreateCommand, IUserGetByLoginQuery userGetByLogin)
        {
            _userCreateCommand = userCreateCommand;
            _userGetByLogin = userGetByLogin;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserCreateRequest request)
        {
            var result = await _userCreateCommand.Execute(request);
            return result.IsSuccess ? Ok(result.GetValue()) : Problem(result.Error);
        }

        [HttpGet("{login}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string login)
        {
            var result = await _userGetByLogin.Execute(login);
            return result.IsSuccess ? Ok(result.GetValue()) : Problem(result.Error);
        }
    }
}
