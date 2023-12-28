using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericFilterRepository<T> where T : class
    {
        Task<Result<List<T>>> Filter(DbContext context, Func<T, bool> condition);
        Task<Result<List<T>>> Filter(DbContext context, string condition);
    }
}
