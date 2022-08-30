using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaGeeksHubs.Domain.Repositories;
using PruebaGeeksHubs.Infrastructure.Contexts;
using PruebaGeeksHubs.Infrastructure.Repositories;

namespace PruebaGeeksHubs.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TiendaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #region Repositories
            services.AddTransient<ICategoriasRepository, CategoriasRepository>();
            services.AddTransient<IClientesRepository, ClientesRepository>();
            #endregion Repositories
        }
    }
}
