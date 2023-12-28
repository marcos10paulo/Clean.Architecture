using Clean.Architecture.Application.Interfaces.Authentication;
using Clean.Architecture.Application.Interfaces.Data.Repositories;
using Clean.Architecture.Application.Interfaces.Security;
using Clean.Architecture.Infra.Authentication;
using Clean.Architecture.Infra.Generic;
using Clean.Architecture.Infra.Repositories;
using Clean.Architecture.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

namespace Clean.Architecture.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddContext(configuration);
            
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddSingleton<IEncryptationService, EncryptationService>();
            services.AddGenericData();
            services.AddAuth(configuration);

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtAuthentication, JwtAuthentication>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key))
                };

            });

            return services;
        }

        public static IServiceCollection AddContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Context>(option => option
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies()
                .UseChangeTrackingProxies(false)
                .EnableSensitiveDataLogging(Debugger.IsAttached));


            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
