using Limi.Persistence.Postgresql.Context;
using Microsoft.EntityFrameworkCore;

namespace Lirmi.WebApi.Configuration
{
    public static class DbConnection
    {
        public static IServiceCollection RegisterConecctionLirmiDb(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<LirmiDataContext>(x=> x.UseNpgsql(configuration.GetConnectionString("LirmiDB")));
            return services;
        }

    }
}
