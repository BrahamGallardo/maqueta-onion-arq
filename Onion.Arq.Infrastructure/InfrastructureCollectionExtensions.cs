using Onion.Arq.Application.Interfaces;
using Onion.Arq.Infrastructure.Persistence;
using Onion.Arq.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Arq.Application.Interfaces.Repository;

namespace Onion.Arq.Infrastructure
{
    public static class InfrastructureCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var cnn = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OnionArqDbContext>(opt => opt.UseSqlServer(cnn, b => b.MigrationsAssembly(typeof(OnionArqDbContext).Assembly.FullName)))
                .AddScoped<IOnionArqDbContext>(provider => provider.GetRequiredService<OnionArqDbContext>())
                .AddTransient(typeof(IRepositoryAsyncArdalis<>), typeof(RepositoryAsyncArdalis<>))
                .AddTransient(typeof(IRepositoryCommandAsync<>), typeof(RepositoryCommandAsync<>))
                .AddTransient(typeof(IRepositoryQueryAsync<>), typeof(RepositoryQueryAsync<>))
                ;

            return services;
        }
    }
}