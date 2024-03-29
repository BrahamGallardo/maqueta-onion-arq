﻿using Microsoft.Extensions.DependencyInjection;
using Onion.Arq.Application.Common;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Services;
using Onion.Arq.Application.Services.UserService;

namespace Onion.Arq.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<ISessionAsyncService, SessionAsyncService>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IUserCommandService, UserCommandService>();

            return services;
        }
    }
}