using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class InitialValueGreaterThanFinalValueValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorInitialValue;
        private readonly string _selectorFinalValue;
        public Error Error { get; }

        public InitialValueGreaterThanFinalValueValidationRule(
            string selectorInitialValue,
            string selectorFinalValue,
            Error error)
        {
            _selectorInitialValue = selectorInitialValue;
            _selectorFinalValue = selectorFinalValue;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo propInitialValue = ReflectableValidationRuleUtils.GetProp(entity, _selectorInitialValue);
            PropertyInfo propFinalValue = ReflectableValidationRuleUtils.GetProp(entity, _selectorFinalValue);

            ReflectableValidationRuleUtils.ValidateNumericType(propFinalValue);
            ReflectableValidationRuleUtils.ValidateNumericType(propInitialValue);

            if ((double)propInitialValue.GetValue(entity) > (double)propFinalValue.GetValue(entity))
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
