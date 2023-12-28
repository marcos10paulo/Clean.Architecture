using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericCreateRepository<T> : IGenericCreateRepository<T> where T : class
	{

        public GenericCreateRepository() { }

        public async Task<Result<T>> Create(DbContext context, T entity)
		{
			try
			{
				DbSet<T> entitySet = context.Set<T>();
				await entitySet.AddAsync(entity);
				await context.SaveChangesAsync();

				T localEntity = context.Set<T>().Local.FirstOrDefault(entity);

				if (localEntity != null)
				{
					context.Entry(entity).State = EntityState.Detached;
				}

				return Result<T>.Ok(entity);
			}
			catch (Exception e)
			{
				if (e.InnerException != null)
					return Result<T>.Fail(
						Error.Unexpected(code: e.InnerException.Source, description: e.InnerException.Message)
					);
				else
					return Result<T>.Fail(
						Error.Unexpected(code: e.Source, description: e.Message)
					);
			}
		}
	}
}
