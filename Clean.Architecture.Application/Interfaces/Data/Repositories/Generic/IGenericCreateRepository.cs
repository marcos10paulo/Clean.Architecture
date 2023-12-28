using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericCreateRepository<T> where T : class
    {
        Task<Result<T>> Create(DbContext context, T entity);
    }
}
