using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.DigitalCertificateValueObject
{
	public class DigitalCertificate : IValidable<DigitalCertificate>
	{
		public DigitalCertificate(
			string serialNumber,
			DigitalCertificateType? type,
			string name,
			string issuer,
			DateTime? startDate,
			DateTime? endDate,
			byte[] file)
		{
			SerialNumber = serialNumber;
			Type = type;
			Name = name;
			Issuer = issuer;
			StartDate = startDate;
			EndDate = endDate;
			File = file;
		}

		public string SerialNumber { get; private set; }
		public DigitalCertificateType? Type { get; private set; }
		public string Name { get; private set; }
		public string Issuer { get; private set; }
		public DateTime? StartDate { get; private set; }
		public DateTime? EndDate { get; private set; }
		public byte[] File { get; private set; }



		public static Result<DigitalCertificate> Create(
			string serialNumber,
			DigitalCertificateType? type = null,
			string name = null,
			string issuer = null,
			DateTime? startDate = null,
			DateTime? endDate = null,
			byte[] file = null)
		{
			DigitalCertificate obj = new DigitalCertificate(serialNumber, type, name, issuer, startDate, endDate, file);

			return new DigitalCertificateValidationBuilder().Builder.ValidateBatch(obj);
		}

		public Result<DigitalCertificate> Validate(DigitalCertificate value)
		{
			return new DigitalCertificateValidationBuilder().Builder.ValidateBatch(value);
		}
	}
}
