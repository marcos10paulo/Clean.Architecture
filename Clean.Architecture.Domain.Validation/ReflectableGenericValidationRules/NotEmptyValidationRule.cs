using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class NotEmptyValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        public Error Error { get; }

        public NotEmptyValidationRule(string selectorProp, Error error)
        {
            _selectorProp = selectorProp;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateStringType(prop);

            //bool isInvalid = 
            //   string.IsNullOrWhiteSpace(
            //        (string)prop.GetValue(entity)
            //        ?? ((IDictionary<string, object>)entity)[_selectorProp].ToString()
            //    );

            if (string.IsNullOrWhiteSpace((string)prop.GetValue(entity)))
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
