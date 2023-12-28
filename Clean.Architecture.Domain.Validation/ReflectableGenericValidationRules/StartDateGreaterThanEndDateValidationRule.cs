using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.ReflectableGenericValidationRules
{
    public class StartDateGreaterThanEndDateValidationRule : IReflectableValidationRule
    {
        private readonly string _selectorStartDate;
        private readonly string _selectorEndDate;
        public Error Error { get; }

        public StartDateGreaterThanEndDateValidationRule(
            string selectorStartDate,
            string selectorEndDate,
            Error error)
        {
            _selectorStartDate = selectorStartDate;
            _selectorEndDate = selectorEndDate;
            Error = error;
        }

        public Result<T> Validate<T>(T entity)
        {
            PropertyInfo propStartDate = ReflectableValidationRuleUtils.GetProp(entity, _selectorStartDate);
            PropertyInfo propEndDate = ReflectableValidationRuleUtils.GetProp(entity, _selectorEndDate);

            ReflectableValidationRuleUtils.ValidateDateTimeType(propStartDate);
            ReflectableValidationRuleUtils.ValidateDateTimeType(propEndDate);

            DateTime? startDate = (DateTime?)propStartDate.GetValue(entity);
            DateTime? endDate = (DateTime?)propEndDate.GetValue(entity);

            if (startDate != null && endDate != null)
            {
                if (startDate > endDate)
                {
                    return Result<T>.Fail(Error);
                }
            }

            return Result<T>.Ok();
        }
    }
}
