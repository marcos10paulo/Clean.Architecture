using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseUpdateListRepository<T> where T : class
    {
        Task<Result<IEnumerable<T>>> Update(IEnumerable<T> entities, Func<T, bool> filter);
    }
}
