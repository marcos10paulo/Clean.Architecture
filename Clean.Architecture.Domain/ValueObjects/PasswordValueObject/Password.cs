using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.PasswordValueObject
{
	public class Password : IValidable<Password>
    {
        public string Value { get; private set; }

        private Password(
            string value
        )
        {
            Value = value;
        }

        public static Result<Password> Create(string value)
        {
            Password password = new (value);
            return new PasswordValidationBuilder().Builder.ValidateBatch(password);
        }

		public Result<Password> Validate(Password value)
		{
			return new PasswordValidationBuilder().Builder.ValidateBatch(value);
		}
	}
}
