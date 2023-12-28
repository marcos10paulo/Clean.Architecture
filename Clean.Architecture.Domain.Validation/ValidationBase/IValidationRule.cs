using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.ValidationBase
{
    public interface IValidationRule<T>
    {
        Result<T> Validate(T entity);
        Error Error { get; }
    }
}
