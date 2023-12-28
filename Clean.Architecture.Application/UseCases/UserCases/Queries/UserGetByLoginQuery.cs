using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Queries;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.UserCases.Queries
{
    internal class UserGetByLoginQuery : IUserGetByLoginQuery
    {
        private readonly IUserRepository _userRepository;

        public UserGetByLoginQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Execute(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}
