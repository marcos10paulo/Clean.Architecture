using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class MinimunLengthValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        private readonly int _minLength;
        public Error Error { get; }

        public MinimunLengthValidationRule(string selectorProp, int minLength, Error error)
        {
            _selectorProp = selectorProp;
            _minLength = minLength;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateStringType(prop);

            if (((string)prop.GetValue(entity)).Length < _minLength)
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
