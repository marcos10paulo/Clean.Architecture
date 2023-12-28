using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Entities.UserEntity.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error EmptyUserName = Error.Validation(
                code: "User.EmptyUserName",
                description: "Nome do usuário não informado!"
            );

            public static Error EmptyPassword = Error.Validation(
                code: "User.EmptyPassword",
                description: "Senha do usuário não informado!"
            );

            public static Error InvalidCredentials = Error.Validation(
                code: "User.InvalidCredentials",
                description: "Usuário e/ou senha inválidas!"
            );
        }
    }
}
