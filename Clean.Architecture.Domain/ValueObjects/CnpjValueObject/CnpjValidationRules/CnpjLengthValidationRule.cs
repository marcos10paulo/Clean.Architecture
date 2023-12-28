using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CnpjValueObject.CnpjValidationRules
{
    public class CnpjLengthValidationRule : IReflectableValidationRule
    {
        public Error Error => Errors.Cnpj.CnpjLength;
        private const int REQUIRED_LENGTH = 14;

        public Result<T> Validate<T>(T cnpj)
        {
            if (typeof(T) != typeof(Cnpj))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cnpj, "Value");

            string value = prop.GetValue(cnpj).ToString();

            if (value.Length != REQUIRED_LENGTH)
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cnpj);
        }
    }
}
