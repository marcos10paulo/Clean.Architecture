using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.CnpjValueObject
{
    public class Cnpj : IValidable<Cnpj>
    {
        public string Value { get;  }

        private Cnpj(string value)
        {
            Value = value;
        }

        public static Result<Cnpj> Create(string value)
        {
            Cnpj cpf = new (value);

            return new CnpjValidationBuilder().Builder.ValidateBatch(cpf);
        }
        public Result<Cnpj> Validate(Cnpj value)
		{
            return new CnpjValidationBuilder().Builder.ValidateBatch(value);
        }

        public static string AddMask(string cnpj)
        {
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
        }

        public static string RemoveMask(string cnpj)
        {
            return $"{cnpj.Replace(".","").Replace("/","").Replace("-","")}";
        }
	}
}
