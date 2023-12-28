using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Base
{
    public interface IBaseListRepository<T> where T : class
    {
        Task<Result<List<T>>> List();
    }
}
