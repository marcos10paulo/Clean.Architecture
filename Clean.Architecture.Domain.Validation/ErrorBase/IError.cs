namespace Clean.Architecture.Domain.Validation.ErrorBase
{
    public interface IError
    {
        List<Error> Errors { get; }
        bool IsError { get; }
    }
}
