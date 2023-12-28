using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class GreaterThanMinDateValidationRule : IReflectableValidationRule
    {

        private readonly string _selectorProp;
        public Error Error { get; }

        public GreaterThanMinDateValidationRule(string selectorProp, Error error)
        {
            _selectorProp = selectorProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateDateTimeType(prop);

            if ((DateTime)prop.GetValue(entity) <= DateTime.MinValue)
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
