using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
    public static partial class Errors
	{
		public static class DigitalCertificate
		{
			public static Error EmptySerialNumber = Error.Validation(
				code: "DigitalCertificate.EmptySerialNumber",
				description: "Número do Serial do certificado digital não informado!"
			);

			public static Error EmptyName = Error.Validation(
				code: "DigitalCertificate.EmptyName",
				description: "Nome no certificado digital não informado!"
			);

			public static Error EmptyIssuer = Error.Validation(
				code: "DigitalCertificate.EmptyIssuer",
				description: "Emissor do certificado digital não informado!"
			);

			public static Error StartDateGreaterThanEndDate = Error.Conflict(
				code: "DigitalCertificate.StartDateGreaterThanEndDate",
				description: "Data inicial do certificado digital maior que a data final!"
			);

			public static Error EmptyFile = Error.Validation(
				code: "DigitalCertificate.EmptyFile",
				description: "Arquivo do certificado não informado!"
			);
		}
	}
}
