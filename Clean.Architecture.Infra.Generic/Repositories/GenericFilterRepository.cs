using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericFilterRepository<T> : IGenericFilterRepository<T> where T : class
    {
		public async Task<Result<List<T>>> Filter(DbContext context, Func<T, bool> condition)
		{
			try
			{

				DbSet<T> entitySet = context.Set<T>();
				List<T> entities = await entitySet.ToListAsync();

				if (entities != null || entities.Count != 0)
				{
					return Result<List<T>>.Ok(entities.Where(condition).ToList());
				}
				else
				{
					return Result<List<T>>.Fail(Error.NotFound($"{nameof(T)} não encontrado."));
				}
			}
			catch (Exception e)
			{
				return Result<List<T>>.Fail(
				  Error.Unexpected(code: e.Source, description: e.Message)
				);
			}
		}

		public async Task<Result<List<T>>> Filter(DbContext context, string condition)
		{
			try
			{				
				DbSet<T> entitySet = context.Set<T>();

				var list = entitySet.Where(condition);

				return Result<List<T>>.Ok(list.ToList());
			}
			catch (Exception e)
			{
				return Result<List<T>>.Fail(
				  Error.Unexpected(code: e.Source, description: e.Message)
				);
			}
		}

		public bool IsDbContext(object context)
		{
            return context is DbContext;
		}
	}
}
