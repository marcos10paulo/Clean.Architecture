using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class NotNullOneOfSeveralValidationRule : IReflectableValidationRule
    {
        private readonly string[] _selectorsProp;
        public Error Error { get; }

        public NotNullOneOfSeveralValidationRule(string[] selectorsProp, Error error)
        {
            _selectorsProp = selectorsProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            foreach (var selectorProp in _selectorsProp)
            {
                PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, selectorProp);

                if (prop.GetValue(entity) != null)
                {
                    return Result<T>.Ok();
                }
            }

            return Result<T>.Fail(Error);
        }
    }
}
