using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        private readonly IGenericCreateRepository<User> _createRepository;
        private readonly IGenericUpdateRepository<User> _updateRepository;
        private readonly IGenericListRepository<User> _listRepository;
        private readonly IGenericGetRepository<User> _getRepository;

        public UserRepository(
            Context context, 
            IGenericCreateRepository<User> createRepository, 
            IGenericUpdateRepository<User> updateRepository, 
            IGenericListRepository<User> listRepository, 
            IGenericGetRepository<User> getRepository)
        {
            _context = context;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
            _listRepository = listRepository;
            _getRepository = getRepository;
        }

        public async Task<Result<User>> Create(User entity)
        {
            return await _createRepository.Create(_context, entity);
        }

        public async Task<Result<User>> Get(int id, bool? asNoTracking = true)
        {
            return await _getRepository.Get(_context, id, asNoTracking);
        }

        public async Task<Result<List<User>>> List()
        {
            return await _listRepository.List(_context);
        }

        public async Task<Result<User>> Update(User entity)
        {
            return await _updateRepository.Update(_context, entity);
        }

        public Result<User> GetByLogin(string username)
        {
            User user = _context.Users.Where(w => w.UserName == username ).FirstOrDefault();

            if (user == null) return Result<User>.Fail(Error.NotFound(description: "Usuário não encontrado!"));

            return Result<User>.Ok(user);
        }
    }
}
