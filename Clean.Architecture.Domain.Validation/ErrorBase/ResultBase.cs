namespace Clean.Architecture.Domain.Validation.ErrorBase
{
    public abstract class ResultBase
    {
        public virtual Error Error { get; protected set; }
        public virtual bool IsFailure { get; protected set; }
        public virtual bool IsSuccess { get; protected set; }
    }
}
