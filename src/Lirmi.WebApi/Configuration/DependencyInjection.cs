using System.Reflection;
using Limi.Persistence.Postgresql.Repositories;
using Lirmi.Aplication.Services;
using Lirmi.Domain.Reposiotires;

namespace Lirmi.WebApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Limi.Persistence.Postgresql"));
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddTransient<ICursoAsignaturaRepository, CursoAsignaturRepository>();
            services.AddScoped<IColegioRepository, ColegioRepository>();
            services.AddTransient<IAsignaturaRepository, AsignaturaRepository>();
            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CursoService>();
            services.AddTransient<AsignaturaService>();
            services.AddScoped<ColegioService>();
            services.AddTransient<CursoAsignaturaService>();
            return services;
        }
    }
}
