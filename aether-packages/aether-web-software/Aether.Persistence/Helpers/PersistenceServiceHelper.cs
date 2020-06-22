using Aether.Application.Data.Repositories;
using Aether.Persistence.Data;
using Aether.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aether.Persistence.Helpers
{
    /// <summary>
    /// Helper that registers persistence services inside a service collection
    /// </summary>
    public static class PersistenceServiceHelper
    {
        /// <summary>
        /// Adds persistence services to the <paramref name="services"/> service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AetherDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AetherDatabase")));

            services.AddScoped<IDBContext>(provider => provider.GetService<AetherDBContext>());
            services.AddScoped(typeof(IRepository<>), typeof(DBRepository<>));

            return services;
        }

    }
}
