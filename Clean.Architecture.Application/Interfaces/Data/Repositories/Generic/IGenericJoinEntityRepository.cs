using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Application.Interfaces.Data.Repositories.Generic
{
    public interface IGenericJoinEntityRepository<T> where T : class
    {
        Task<Result<string>> JoinEntity<TEntity, TDomain>(DbContext context, ICollection<TEntity> list, string propertyName, IEnumerable<TDomain> ids)
            where TEntity : class
            where TDomain : BaseEntity;
    }
}
