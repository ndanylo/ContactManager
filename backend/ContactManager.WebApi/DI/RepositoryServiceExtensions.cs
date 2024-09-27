using ContactManager.Domain.Abstractions;
using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Repositories;
using ContactManager.Infrastructure.Persistence.Read.Models;

namespace ContactManager.WebApi.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IWriteRepository<Person, long>, PersonWriteRepository>();
            services.AddScoped<IReadRepository<PersonReadModel, long>, PersonReadRepository>();
            return services;
        }
    }
}
