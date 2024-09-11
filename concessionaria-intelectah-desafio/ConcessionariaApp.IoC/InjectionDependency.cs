using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using ConcessionariaApp.Infrastructure.Config;
using ConcessionariaApp.Infrastructure.Repositories;
using ConcessionariaApp.Infrastructure.Services;
using ConcessionariaApp.Infrastructure.UnitOfWork;
using ConcessionariaApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Services;
using ConcessionariaApp.Application.Mapping;

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
            services.AddHttpContextAccessor();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IConcessionariaRepository, ConcessionariaRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<ICashingService, CashingService>();

            services.AddAutoMapper(typeof(DtoForEntityMapping));
            services.AddAutoMapper(typeof(EntityForDtoMapping));
            services.AddAutoMapper(typeof(DtoForCommandMapping));
            services.AddAutoMapper(typeof(CommandForDtoMapping));
            
            var assembly = AppDomain.CurrentDomain.Load("ConcessionariaApp.Application");
            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
