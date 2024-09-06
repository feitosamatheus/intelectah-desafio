using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ConcessionariaApp.Infrastructure.Autentications;
using Microsoft.AspNetCore.Authentication.Cookies;

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

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Usuario, IdentityRole>()
            .AddUserStore<UsuarioStoreCustom>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            return services;
        }
    }
}
