using Onion.Arq.Application.Common;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Services;
using Onion.Arq.Application.Services.UserService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Onion.Arq.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<ISessionAsyncService, SessionAsyncService>();
            services.AddScoped<IUserAsyncService, UserAsyncService>();

            return services;
        }
    }
}