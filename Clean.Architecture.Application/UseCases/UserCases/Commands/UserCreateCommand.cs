using Clean.Architecture.Application.Extensions.Transaction;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Security;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Commands;
using Clean.Architecture.Contracts.UserContracts;
using Clean.Architecture.Domain.Entities.UserEntity;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.UseCases.UserCases.Commands
{
    public class UserCreateCommand : IUserCreateCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransactionBuilder _transactionBuilder;
        private readonly IEncryptationService _encryptationService;

        public UserCreateCommand(IUserRepository userRepository, ITransactionBuilder transactionBuilder, IEncryptationService encryptationService)
        {
            _userRepository = userRepository;
            _transactionBuilder = transactionBuilder;
            _encryptationService = encryptationService;
        }

        public async Task<Result<User>> Execute(UserCreateRequest request, int? userId = null)
        {
            Result<User> resultUser = User.Create(request.Username, request.Password);

            var passwordEncrypted = _encryptationService.GetMD5(request.Password);
            passwordEncrypted = _encryptationService.Encrypt(passwordEncrypted);

            if (resultUser.IsFailure)
                return Result<User>.Fail(resultUser.Error);

            using (var transaction = _transactionBuilder.OpenTransaction())
            {
                resultUser = await _userRepository.Create(resultUser.GetValue());

                if (resultUser.IsFailure)
                {
                    transaction.Rollback();
                    return Result<User>.Fail(resultUser.Error);
                }

                transaction.Commit();
            }

            return resultUser;
        }
    }
}
