using Clean.Architecture.Application.Interfaces.Data.Repositories.Generic;
using Clean.Architecture.Application.Interfaces.Transaction;
using Clean.Architecture.Infra.Generic.Transaction;
using Clean.Architecture.Infra.GenericData.Generic;
using Clean.Architecture.Infra.GenericData.GenericRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Infra.Generic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGenericData(
            this IServiceCollection services
        )
        {

            //Generic Repositories
            services.AddScoped(typeof(IGenericCreateRepository<>), typeof(GenericCreateRepository<>));
            services.AddScoped(typeof(IGenericDeleteRepository<>), typeof(GenericDeleteRepository<>));
            services.AddScoped(typeof(IGenericListRepository<>), typeof(GenericListRepository<>));
            services.AddScoped(typeof(IGenericUpdateRepository<>), typeof(GenericUpdateRepository<>));
            services.AddScoped(typeof(IGenericGetRepository<>), typeof(GenericGetRepository<>));
            services.AddScoped(typeof(IGenericFilterRepository<>), typeof(GenericFilterRepository<>));
            services.AddScoped(typeof(IGenericJoinEntityRepository<>), typeof(GenericJoinEntityRepository<>));
            services.AddScoped(typeof(IGenericListUpdateRepository<>), typeof(GenericListUpdateRepository<>));

            //Transction Builder
            services.AddTransient<ITransactionBuilder, TransactionBuilder>();

            //Repositories

            return services;
        }
    }
}
