using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
	public static partial class Errors
	{
		public static class Email
		{
			public static Error InvalidFormat = Error.Validation(
				code: "Email.InvalidFormat",
				description: "Email em formato inválido!"
			);
		}
	}
}
