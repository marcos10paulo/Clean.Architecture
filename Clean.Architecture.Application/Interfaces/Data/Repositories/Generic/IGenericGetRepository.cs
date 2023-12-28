using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericGetRepository<T> where T : class
    {
        Task<Result<T>> Get(DbContext context, int id, bool? asNoTracking = true);
    }
}
