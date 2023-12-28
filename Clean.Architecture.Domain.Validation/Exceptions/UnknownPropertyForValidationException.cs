namespace Clean.Architecture.Domain.Validation.Exceptions
{
    public class UnknownPropertyForValidationException : Exception
    {
        public UnknownPropertyForValidationException(string msg)
            : base(msg)
        {
        }
    }
}
