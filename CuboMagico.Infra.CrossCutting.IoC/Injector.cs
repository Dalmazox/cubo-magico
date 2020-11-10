using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.UoW;
using CuboMagico.Infra.Data.Context;
using CuboMagico.Infra.Data.Repositories;
using CuboMagico.Infra.Data.Repositories.Config;
using CuboMagico.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CuboMagico.Infra.CrossCutting.IoC
{
    public static class Injector
    {
        public static void RegisterIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .RegisterContext(configuration)
                .RegisterRepositories()
                .RegisterServices()
                .RegisterBuilders();
        }

        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<CuboContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services
                .Configure<RepositoryConfig>(x =>
                    x
                    .AddBind<IUsuarioRepository, UsuarioRepository>()
                    .AddBind<ISoftwareRepository, SoftwareRepository>()
                );

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterBuilders(this IServiceCollection services)
        {
            return services;
        }
    }
}
