using Clean.Architecture.Contracts.AuthContracts;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.AuthCases.Commands
{
    public interface IAuthenticationCommand
    {
        Task<Result<AuthResponse>> Execute(AuthRequest authRequest);
    }
}
