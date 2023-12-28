using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericListRepository<T> : IGenericListRepository<T> where T : class
    {
		public async Task<Result<List<T>>> List(DbContext context)
        {
            try
            {
				DbSet<T> entitySet = context.Set<T>();

                List<T> entities = await entitySet.ToListAsync();
                return Result<List<T>>.Ok(entities);
            }
            catch (Exception e)
            {
                return Result<List<T>>.Fail(
                  Error.Unexpected(code: e.Source, description: e.Message)
                );
            }
		}
	}
}
