using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericJoinEntityRepository<T> : IGenericJoinEntityRepository<T>
        where T : class
    {
		public async Task<Result<string>> JoinEntity<TEntity, TDomain>(
			DbContext context, 
			ICollection<TEntity> list, 
			string propertyName, 
			IEnumerable<TDomain> newJoinEntity
		) 
			where TEntity : class
            where TDomain : BaseEntity
        {
			try
			{
				if (list == null)
					return Result<string>.Ok();

				DbSet<T> dbSet = context.Set<T>();				
				dbSet.AsNoTracking().Include(propertyName).Load();
				list.Clear();

				if (newJoinEntity != null)
				{
					var dbSetInternal = context.Set<TEntity>();
					foreach (var id in newJoinEntity.Select(s => s.Id))
					{
						TEntity item = dbSetInternal.Find(id);
						if (item != null) 
							list.Add(item);
					}
				}

				await context.SaveChangesAsync();

				return Result<string>.Ok();
			}
			catch (Exception e)
			{
				if (e.InnerException != null)
					return Result<string>.Fail(
						Error.Unexpected(code: e.InnerException.Source, description: e.InnerException.Message)
					);
				else
					return Result<string>.Fail(
						Error.Unexpected(code: e.Source, description: e.Message)
					);
			}
		}
	}
}
