using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericUpdateRepository<T> where T : class
    {
        Task<Result<T>> Update(DbContext context, T entity);
    }
}
