using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CpfValueObject.CpfValidationRules
{
    public class CpfLengthValidationRule : IReflectableValidationRule
    {
		public Error Error => Errors.Cpf.CpfLength;
        private const int REQUIRED_LENGTH = 11;

        public Result<T> Validate<T>(T cpf)
        {

            if (typeof(T) != typeof(Cpf))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cpf, "Value");

            string value = prop.GetValue(cpf).ToString();

            if (value.Length != REQUIRED_LENGTH)
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cpf);
        }
    }
}
