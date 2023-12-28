using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CnpjValueObject.CnpjValidationRules
{
    public class CnpjSequentialValidationRule : IReflectableValidationRule
    {
        public Error Error => Errors.Cnpj.CnpjSequential;

        public Result<T> Validate<T>(T cnpj)
        {
            if (typeof(T) != typeof(Cnpj))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cnpj, "Value");

            string value = prop.GetValue(cnpj).ToString();

            if (!IsValid(value))
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cnpj);
        }

        private bool IsValid(string cnpj)
        {
            int distinctNumbers = cnpj.Select(c => c - '0')
                .ToArray().Distinct().Count();

            return distinctNumbers > 1;
        }
    }
}
