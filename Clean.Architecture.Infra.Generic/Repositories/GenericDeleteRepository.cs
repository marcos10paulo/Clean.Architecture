using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericDeleteRepository<T> : IGenericDeleteRepository<T> where T : class
    {
        public GenericDeleteRepository() { }

        public async Task<Result<T>> Delete(DbContext context, int id)
        {
            try
            {

				DbSet<T> entitySet = context.Set<T>();

                T entity = await entitySet.FindAsync(id);

                if (entity != null)
                {
                    entitySet.Remove(entity);
                    return Result<T>.Ok(entity);
                }
                else
                {
                    return Result<T>.Fail(Error.NotFound("Entity not found."));
                }
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
