using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Infra.Generic.Compare;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericListUpdateRepository<T> : IGenericListUpdateRepository<T> where T : BaseEntity
	{
		public bool IsDbContext(object context)
		{
			return context is DbContext;
		}

		public async Task<Result<IEnumerable<T>>> Update(DbContext context, IEnumerable<T> entities, Func<T, bool> filter)
		{
			try
			{
				DbSet<T> entitySet = context.Set<T>();

				var oldEntities = entitySet.Where(filter);

				ModelIdEquilityCompare compare = new ();

				var entitiesToDelete = oldEntities.Except(entities, compare);
				var entitiesToInsert = entities.Where(a => a.Id == 0);
				var entitiesToUpdate = entities.Where(a => a.Id > 0);

				foreach (var item in entitiesToUpdate)
				{
					context.Entry(item).State = EntityState.Modified;
					entitySet.Update(item);
				}

				foreach (var item in entitiesToInsert)
				{
					context.Entry(item).State = EntityState.Added;
					await entitySet.AddAsync((T)item);
				}

				foreach (var item in entitiesToDelete)
				{
					context.Entry(item).State = EntityState.Deleted;
				}

				await context.SaveChangesAsync();

				return Result<IEnumerable<T>>.Ok((IEnumerable<T>)entitiesToInsert.Union(entitiesToUpdate));
			}
			catch (Exception e)
			{
				return Result<IEnumerable<T>>.Fail(
					Error.Unexpected(code: e.Source, description: e.Message)
				);
			}
		}
	}
}
