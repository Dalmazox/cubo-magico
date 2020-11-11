using AutoMapper;
using CuboMagico.Application.Builders;
using CuboMagico.Application.Helpers;
using CuboMagico.Application.Services;
using CuboMagico.Domain.Interfaces.Builders;
using CuboMagico.Domain.Interfaces.Helpers;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Domain.Interfaces.Services;
using CuboMagico.Domain.Interfaces.UoW;
using CuboMagico.Infra.CrossCutting.Mapper.Profiles;
using CuboMagico.Infra.Data.Context;
using CuboMagico.Infra.Data.Repositories;
using CuboMagico.Infra.Data.Repositories.Config;
using CuboMagico.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CuboMagico.Infra.CrossCutting.IoC
{
    public static class Injector
    {
        public static void RegisterIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .RegisterContext(configuration)
                .RegisterRepositories()
                .RegisterBuilders()
                .RegisterServices()
                .RegisterHelpers()
                .RegisterMapper();
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
            services
                .AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }

        public static IServiceCollection RegisterBuilders(this IServiceCollection services)
        {
            services
                .AddScoped<IRetornoBuilder, RetornoBuilder>();

            return services;
        }

        public static IServiceCollection RegisterHelpers(this IServiceCollection services)
        {
            services
                .AddScoped<IRetornoHelper, RetornoHelper>();

            return services;
        }

        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services
                .AddAutoMapper(new Assembly[] { typeof(UsuarioProfile).Assembly });

            return services;
        }
    }
}
