using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class MinimunEnumerableLengthValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        private readonly int _minLength;
        public Error Error { get; }

        public MinimunEnumerableLengthValidationRule(string selectorProp, int minLength, Error error)
        {
            _selectorProp = selectorProp;
            _minLength = minLength;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateCollectionType(prop);

            var propValue = prop.GetValue(entity);

            if (propValue == null)
                return Result<T>.Fail(Error);

            Type propType = propValue.GetType();
            MethodInfo countMethod = propType.GetMethod("get_Count");

            if (countMethod == null)
                return Result<T>.Fail(Error);

            int count = (int)countMethod.Invoke(propValue, null);

            if (count < _minLength)
                return Result<T>.Fail(Error);

            return Result<T>.Ok();
        }
    }
}
