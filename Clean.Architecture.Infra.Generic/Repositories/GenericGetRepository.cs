using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace Clean.Architecture.Infra.GenericData.GenericRepositories
{
    public class GenericGetRepository<T> : IGenericGetRepository<T> where T : class
    {

		public async Task<Result<T>> Get(DbContext context, int id, bool? asNoTracking = true)
        {
			try
			{
				string condition = GetCondition(id);

				DbSet<T> entitySet = context.Set<T>();

				T entity =
					asNoTracking.Value
					? await entitySet.AsNoTracking().Where(condition).FirstOrDefaultAsync()
					: await entitySet.Where(condition).FirstOrDefaultAsync();


				if (entity != null)
					return Result<T>.Ok(entity);
				else
					return Result<T>.Fail(Error.NotFound($"{nameof(T)} não encontrado."));
			}
			catch (Exception e)
			{
				return Result<T>.Fail(Error.Unexpected(code: e.Source, description: e.Message));
			}
		}

		public bool IsDbContext(object obj)
		{
			return obj is DbContext;
		}

		public string GetCondition(object id)
		{
			var propertyName = GetKeyProperty();
			return $"{propertyName} == {Convert.ToInt32(id)}";			
		}

		private string GetKeyProperty()
		{
            string propertyName = "";			

			foreach (PropertyInfo property in typeof(T).GetProperties())
			{
				KeyAttribute keyAttributes = property.GetCustomAttribute<KeyAttribute>();

                if (keyAttributes != null)
                {
					propertyName = property.Name;					
					break;
				}
			}

			return propertyName;
		}

	}
}
