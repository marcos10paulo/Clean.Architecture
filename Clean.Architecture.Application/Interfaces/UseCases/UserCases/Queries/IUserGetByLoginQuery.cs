using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Queries
{
    public interface IUserGetByLoginQuery
    {
        Task<Result<User>> Execute(string login);
    }
}
