using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Infrastructure.Services;

namespace ConcessionariaApp.Infrastructure.Config
{
    public static class ConfigInfra
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextApp>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            return services;
        }

        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "ConcessionariaApp";
            });

            return services;
        }
    }
}
