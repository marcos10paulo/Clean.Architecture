using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class LessThanZeroValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        public Error Error { get; }

        public LessThanZeroValidationRule(string selectorProp, Error error)
        {
            _selectorProp = selectorProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateNumericType(prop);

            if ((double)prop.GetValue(entity) < 0)
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
