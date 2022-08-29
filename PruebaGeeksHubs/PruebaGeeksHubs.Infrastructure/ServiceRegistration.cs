using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaGeeksHubs.Infrastructure.Contexts;

namespace PruebaGeeksHubs.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TiendaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #region Repositories
            #endregion Repositories
        }
    }
}
