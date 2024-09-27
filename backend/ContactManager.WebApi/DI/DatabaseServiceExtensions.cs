using Microsoft.EntityFrameworkCore;
using ContactManager.Infrastructure.Persistence.Read.Models;

namespace ContactManager.WebApi.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PersonDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<PersonReadModelDbContext>(options =>
                options.UseSqlServer(connectionString)
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return services;
        }
    }
}
