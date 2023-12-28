using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CpfValueObject.CpfValidationRules
{
    public class CpfSequentialValidationRule : IReflectableValidationRule
    {
		public Error Error => Errors.Cpf.CPFSequential;
        public Result<T> Validate<T>(T cpf)
        {
            if (typeof(T) != typeof(Cpf))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cpf, "Value");

            string value = prop.GetValue(cpf).ToString();

            if (!IsValid(value))
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cpf);
        }

        private bool IsValid(string cpf)
        {
            int distinctNumbers = cpf.Select(c => c - '0')
                .ToArray().Distinct().Count();

            return distinctNumbers > 1;
        }
    }
}
