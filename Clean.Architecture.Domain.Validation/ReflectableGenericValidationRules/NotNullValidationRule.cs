using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class NotNullValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        public Error Error { get; }

        public NotNullValidationRule(string selectorProp, Error error)
        {
            _selectorProp = selectorProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            if (prop.GetValue(entity) == null)
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
