using Clean.Architecture.Application.Interfaces.Authentication;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Security;
using Clean.Architecture.Application.Interfaces.UseCases.AuthCases.Commands;
using Clean.Architecture.Contracts.AuthContracts;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Entities.UserEntity.Errors;

namespace Clean.Architecture.Application.UseCases.AuthCases.Commands
{
    public class AuthenticationCommand : IAuthenticationCommand
    {
        private readonly IJwtAuthentication _jwtAuth;
        private readonly IEncryptationService _encryptationService;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommand(IJwtAuthentication jwtAuth, IEncryptationService encryptationService, IUserRepository userRepository)
        {
            _jwtAuth = jwtAuth;
            _encryptationService = encryptationService;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthResponse>> Execute(AuthRequest authRequest)
        {
            Result<User> resultLogin = _userRepository.GetByLogin(authRequest.Username);

            if (resultLogin.IsFailure)
                return Result<AuthResponse>.Fail(resultLogin.Error);

            string passwordDecrypt = _encryptationService.Decrypt(authRequest.Password);
            string password = _encryptationService.GetMD5(passwordDecrypt);

            if (password != authRequest.Password.ToUpper())
                return Result<AuthResponse>.Fail(Errors.User.InvalidCredentials);

            AuthResponse authResponse = new (_jwtAuth.GenerateToken(authRequest.Username, resultLogin.GetValue().Id));

            return Result<AuthResponse>.Ok(authResponse);
        }
    }
}
