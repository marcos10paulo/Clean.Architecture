using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.Entities.UserEntity
{
    public class UserValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public UserValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {
            ReflectableValidationBuilder builder = new (new());

            builder.AddValidation(
                new NotEmptyValidationRule("UserName", Errors.Errors.User.EmptyUserName)
            )
            .AddValidation(
               new NotEmptyValidationRule("Password", Errors.Errors.User.EmptyPassword)
            );

            return builder;
        }
    }
}
