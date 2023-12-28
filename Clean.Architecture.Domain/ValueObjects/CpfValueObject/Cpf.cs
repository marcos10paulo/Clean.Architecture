using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.CpfValueObject
{
    public class Cpf: IValidable<Cpf>
    {
        public string Value { get; private set; }

        private Cpf(string value)
        {
            Value = value;
        }

        public static Result<Cpf> Create(string value)
        {
            Cpf cpf = new Cpf(value);

            return new CpfValidationBuilder().Builder.ValidateBatch(cpf);
        }
        public Result<Cpf> Validate(Cpf value)
		{
            return new CpfValidationBuilder().Builder.ValidateBatch(value);
        }

        public static string AddMask(string cpf)
        {
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9)}";
        }

        public static string RemoveMask(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }
    }
}
