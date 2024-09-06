using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Domain.Interfaces.Services;
using ConcessionariaApp.Infrastructure.Config;
using ConcessionariaApp.Infrastructure.Repositories;
using ConcessionariaApp.Infrastructure.Services;
using ConcessionariaApp.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.IoC
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisConfiguration(configuration);
            services.AddDatabaseConfiguration(configuration);

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IConcessionariaRepository, ConcessionariaRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<ICashingService, CashingService>();

            return services;
        }

    }
}
