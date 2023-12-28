using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.ValidationBase
{
    public interface IReflectableValidationRule
    {
        Result<T> Validate<T>(T entity);
        Error Error { get; }

    }
}
