using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class RegularExpressionValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorProp;
        private readonly string _pattern;
        public Error Error { get; }

        public RegularExpressionValidationRule(string selectorProp, string pattern, Error error)
        {
            _selectorProp = selectorProp;
            _pattern = pattern;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(entity, _selectorProp);

            ReflectableValidationRuleUtils.ValidateStringType(prop);

            if (!Regex.IsMatch((string)prop.GetValue(entity), _pattern))
            {
                return Result<T>.Fail(Error);
            }

            return Result<T>.Ok();
        }
    }
}
