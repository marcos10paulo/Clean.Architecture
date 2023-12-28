using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class MaximumLengthValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        private readonly int _maxLength;
        public Error Error { get; }

        public MaximumLengthValidationRule(string selectorProp, int maxLength, Error error)
        {
            _selectorProp = selectorProp;
            _maxLength = maxLength;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateStringType(prop);

            if (((string)prop.GetValue(entity)).Length > _maxLength)
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
