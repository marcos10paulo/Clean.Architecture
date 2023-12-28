using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.ValueObjects.EmailValueObject
{
    public class EmailValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public EmailValidationBuilder()
        {
            Builder = CreateTemplate();
        }

        private ReflectableValidationBuilder CreateTemplate()
        {

            ReflectableValidationBuilder builder = new ReflectableValidationBuilder(new());

            builder.AddValidation(
                new RegularExpressionValidationRule(
                    "Value",
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    Errors.Email.InvalidFormat
                )
            );

            return builder;
        }
    }
}
