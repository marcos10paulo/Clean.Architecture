using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.EmailValueObject
{
	public class Email : IValidable<Email>
	{
		public string Value { get; private set; }

		private Email(string value)
		{
			Value = value;
		}

		public static Result<Email> Create(string value)
		{
			Email email = new Email(value);

			return new EmailValidationBuilder().Builder.ValidateBatch(email);
		}

		public Result<Email> Validate(Email value)
		{
			return new EmailValidationBuilder().Builder.ValidateBatch(value);
		}
	}
}