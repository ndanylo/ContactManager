using ContactManager.Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ContactManager.WebApi.Extensions
{
    public static class FluentValidationServiceExtensions
    {
        public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<PersonValidator>();

            return services;
        }
    }
}
