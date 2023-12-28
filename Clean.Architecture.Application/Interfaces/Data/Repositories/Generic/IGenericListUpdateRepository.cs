using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericListUpdateRepository<T> where T : class
    {
        Task<Result<IEnumerable<T>>> Update(DbContext context, IEnumerable<T> entities, Func<T, bool> filter);
    }
}
