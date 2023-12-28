using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectionGenericValidationRule
{
    public class GreaterThanZeroValidationRule : IReflectableValidationRule
    {

        private readonly string _selectorProp;
        public Error Error { get; }

        public GreaterThanZeroValidationRule(string selectorProp, Error error)
        {
            _selectorProp = selectorProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateNumericType(prop);

            if (double.TryParse(prop.GetValue(entity).ToString(), out double value))
            {
                if (value <= 0)
                {
                    return Result<T>.Fail(Error);
                }
            }

            return Result<T>.Ok();
        }
    }
}
