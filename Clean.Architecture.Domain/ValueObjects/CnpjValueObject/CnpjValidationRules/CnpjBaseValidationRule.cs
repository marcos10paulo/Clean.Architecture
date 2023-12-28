using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Utils;
using Clean.Architecture.Domain.Validation.ValidationBase;
using Clean.Architecture.Domain.Validation.Errors;
using System.Reflection;

namespace Clean.Architecture.Domain.ValueObjects.CnpjValueObject.CnpjValidationRules
{
    public class CnpjBaseValidationRule : IReflectableValidationRule
    {
        public Error Error => Errors.Cnpj.InvalidValue;

        public Result<T> Validate<T>(T cnpj)
        {
            if(typeof(T) != typeof(Cnpj))
                return Result<T>.Fail(Error);

            PropertyInfo prop = ReflectableValidationRuleUtils.GetProp(cnpj, "Value");

            if (!IsValid(prop.GetValue(cnpj) as string))
                return Result<T>.Fail(Error);

            return Result<T>.Ok(cnpj);
        }

        private bool IsValid(string value)
        {
            int[] cnpj = value.Select(c => c - '0')
                .ToArray();

            int[] cnpjWithoutDigits = new int[12];

            Array.Copy(cnpj, cnpjWithoutDigits, 12);

            int firstDigit = GetFirstVerifyingDigit(cnpjWithoutDigits);
            int secondDigit = GetSecondVerifyingDigit(cnpjWithoutDigits, firstDigit);

            return cnpj[12] == firstDigit && cnpj[13] == secondDigit;
        }

        private int GetFirstVerifyingDigit(int[] cnpj)
        {
            var mod = Enumerable.Range(2, 4).Reverse().Concat(Enumerable.Range(2, 8).Reverse())
                .Select((x, i) => x * cnpj[i]).Sum() % 11;

            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }

        private int GetSecondVerifyingDigit(int[] cnpj, int firstDigit)
        {
            int[] newCnpj = new int[13];

            Array.Copy(cnpj, newCnpj, 12);
            newCnpj[12] = firstDigit;

            var mod = Enumerable.Range(2, 5).Reverse().Concat(Enumerable.Range(2, 8)
                .Reverse()).Select((x, i) => x * newCnpj[i]).Sum() % 11;

            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }
    }
}