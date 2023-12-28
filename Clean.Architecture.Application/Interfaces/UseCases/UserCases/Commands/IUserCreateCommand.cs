using Clean.Architecture.Contracts.UserContracts;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Commands
{
    public interface IUserCreateCommand
    {
        Task<Result<User>> Execute(UserCreateRequest request, int? userId = null);
    }
}
