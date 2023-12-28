using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.ValidationBase
{
    public interface IValidable<T>
    {
        public Result<T> Validate(T value);

    }
}
