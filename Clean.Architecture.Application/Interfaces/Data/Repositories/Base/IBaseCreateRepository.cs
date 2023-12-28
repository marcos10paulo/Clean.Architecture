using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseCreateRepository<T> where T : class
    {
        Task<Result<T>> Create(T entity);
    }
}
