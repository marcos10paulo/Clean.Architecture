using Clean.Architecture.Domain.ValueObjects.PasswordValueObject;
using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Entities.UserEntity
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User() { }

        private User(string userName, string password, int id)
        {
            UserName = userName;
            Password = password;
            Id = id;
        }

        public static Result<User> Create(string username, string password, int id = 0)
        {
            Result<Password> resultPassword = ValueObjects.PasswordValueObject.Password.Create(password);

            if (resultPassword.IsFailure) return Result<User>.Fail(resultPassword.Error);

            User user = new (username, resultPassword.GetValue().Value, id);

            return new UserValidationBuilder().Builder.ValidateBatch(user);
        }
    }
}
