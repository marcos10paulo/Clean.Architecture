namespace Clean.Architecture.Domain.Validation.Exceptions
{
    public class InvalidPropertyTypeForValidationRuleException : Exception
    {
        public InvalidPropertyTypeForValidationRuleException(string msg) : base(msg)
        { }
    }
}
