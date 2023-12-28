using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseUpdateRepository<T> where T : class
    {
        Task<Result<T>> Update(T entity);
    }
}
