using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericDeleteRepository<T>  where T : class
    {
        Task<Result<T>> Delete(DbContext context, int id);
    }
}
