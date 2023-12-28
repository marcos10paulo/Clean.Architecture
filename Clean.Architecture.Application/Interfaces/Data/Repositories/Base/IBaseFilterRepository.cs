using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseFilterRepository<T> where T : class
    {
        Task<Result<List<T>>> Filter(Func<T, bool> condition);
        Task<Result<List<T>>> Filter(string condition);
    }
}
