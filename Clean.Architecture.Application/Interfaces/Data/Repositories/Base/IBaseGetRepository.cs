using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseGetRepository<T> where T : class
    {
        Task<Result<T>> Get(int id, bool? asNoTracking = true);
    }
}
