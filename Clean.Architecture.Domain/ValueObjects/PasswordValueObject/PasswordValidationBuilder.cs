using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules;
using Clean.Architecture.Domain.Validation.ReflectableValidationBuilder;

namespace Clean.Architecture.Domain.ValueObjects.PasswordValueObject
{
    public class PasswordValidationBuilder
    {
        public ReflectableValidationBuilder Builder { get; set; }

        public PasswordValidationBuilder()
        {
            Builder = CreateTemplate();
        }
        private ReflectableValidationBuilder CreateTemplate()
        {

            ReflectableValidationBuilder builder = new (new());

            builder.AddValidation(
                new NotEmptyValidationRule("Value", Errors.Password.EmptyPassword)
            )
            .AddValidation(
                new RegularExpressionValidationRule("Value", @"^(?=.*[\*\&\%\$\#\@\!\?\:\>\<\.\+\-]).*$", Errors.Password.NotSpecialCharacters)
            )
            .AddValidation(
                new RegularExpressionValidationRule("Value", "[a-zA-Z]+", Errors.Password.NonLetterCharacters)
            )
            .AddValidation(
                  new RegularExpressionValidationRule("Value", @"\d+", Errors.Password.NonNumericalCharacters)
            ).AddValidation(
                new MinimunLengthValidationRule("Value", 8, Errors.Password.NotMinimunLength)
            );

            return builder;
        }
    }
}
