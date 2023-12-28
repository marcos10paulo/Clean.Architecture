using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.ValidationBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.Utils;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CpfValueObject.CpfValidationRules
{
    public class CpfBaseValidationRule : IReflectableValidationRule
    {
        public Error Error => Errors.Cpf.InvalidValue;
        public Result<T> Validate<T>(T cpf)
        {
            if (typeof(T) != typeof(Cpf))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cpf, "Value");

            if (!IsValid(prop.GetValue(cpf) as string))
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cpf);
        }
        private bool IsValid(string cpfValue)
        {
            int[] cpf = cpfValue.Select(c => c - '0')
                .ToArray();

            int[] cpfWithoutDigits = new int[9];

            Array.Copy(cpf, cpfWithoutDigits, 9);

            int firstDigit = GetFirstVerifyingDigit(cpfWithoutDigits);
            int secondDigit = GetSecondVerifyingDigit(cpfWithoutDigits, firstDigit);

            return cpf[9] == firstDigit && cpf[10] == secondDigit;
        }

        private int GetFirstVerifyingDigit(int[] cpf)
        {
            var mod = Enumerable.Range(2, 9).Reverse().Select((x, i) => x * cpf[i]).Sum() % 11;

            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }

        private int GetSecondVerifyingDigit(int[] cpf, int firstDigit)
        {
            int[] newCpf = new int[10];

            Array.Copy(cpf, newCpf, 9);
            newCpf[9] = firstDigit;

            var mod = Enumerable.Range(2, 10).Reverse().Select((x, i) => x * newCpf[i]).Sum() % 11;
            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }
    }
}
