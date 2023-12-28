using Clean.Architecture.Application.Interfaces.Data.Repositories.Base;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories
{
    public interface IUserRepository :
        IBaseCreateRepository<User>,
        IBaseUpdateRepository<User>,
        IBaseListRepository<User>,
        IBaseGetRepository<User>
    {

        Result<User> GetByLogin(string username);
    }
}
