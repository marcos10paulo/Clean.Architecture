using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
	public static partial class Errors
	{
		public static class Password
		{
			public static Error EmptyPassword = Error.Validation(
				code: "Password.EmptyPassword",
				description: "Senha não informada!"
				);

			public static Error NotSpecialCharacters = Error.Validation(
				code: "Password.NotSpecialCharacters",
				description: "Senha deve conter pelo menos um caracter especiais!"
				);

			public static Error NonLetterCharacters = Error.Validation(
				code: "Password.NonLetterCharacters",
				description: "Senha deve conter pelo menos uma letra!"
				);

			public static Error NonNumericalCharacters = Error.Validation(
				code: "Password.NomNumericalCharacters",
				description: "Senha deve conter pelo menos um caracter numéricos!"
				);

			public static Error NotMinimunLength = Error.Validation(
				code: "Password.NotMinimunLength",
				description: "Senha deve conter no mínimo de 8 caracteres"
				);
		}
	}
}
