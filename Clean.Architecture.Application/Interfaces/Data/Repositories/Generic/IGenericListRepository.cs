using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericListRepository<T> where T : class
    {
        Task<Result<List<T>>> List(DbContext context);
    }
}
