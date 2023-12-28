namespace Clean.Architecture.Domain.Validation.ErrorBase
{
    public enum ErrorType
    {
        Failure = 0,
        Unexpected = 1,
        Validation = 2,
        Conflict = 3,
        NotFound = 4
    }
}
