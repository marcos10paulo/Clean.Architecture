﻿using Clean.Architecture.Application.Configuration;
using Clean.Architecture.Application.Interfaces.Configuration;
using Clean.Architecture.Application.Interfaces.UseCases.AuthCases.Commands;
using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Commands;
using Clean.Architecture.Application.Interfaces.UseCases.UserCommands.Queries;
using Clean.Architecture.Application.UseCases.AuthCases.Commands;
using Clean.Architecture.Application.UseCases.UserCases.Commands;
using Clean.Architecture.Application.UseCases.UserCases.Queries;
using Clean.Architecture.Contracts.Validators.AuthContracts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Commands
            services.AddScoped<IUserCreateCommand, UserCreateCommand>();
            services.AddScoped<IAuthenticationCommand, AuthenticationCommand>();

            //Queries
            services.AddScoped<IUserGetByLoginQuery, UserGetByLoginQuery>();

            // Environment System
            services.AddScoped<IEnvironmentSystem, EnvironmentSystem>();

            services.AddFluentValidation();

            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AuthRequestValidator>();

            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
