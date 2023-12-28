using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.Generic
{
    public class GenericUpdateRepository<T> : IGenericUpdateRepository<T> where T : BaseEntity
	{
        public GenericUpdateRepository() { }

        public async Task<Result<T>> Update(DbContext context, T entity)
		{
			try
			{
                DbSet<T> entitySet = context.Set<T>();
				context.Entry(entity).State = EntityState.Modified;
				entitySet.Update(entity);
				await context.SaveChangesAsync();

				return Result<T>.Ok(entity);
			}
			catch (Exception e)
			{
				return Result<T>.Fail(
					Error.Unexpected(code: e.Source, description: e.Message)
				);
			}
		}
	}
}
