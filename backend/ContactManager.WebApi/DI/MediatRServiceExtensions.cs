using ContactManager.Application.Commands.CreateContact;
using ContactManager.Application.Commands.RemoveContact;
using ContactManager.Application.Commands.UpdateContact;
using ContactManager.Application.Commands.GetAllContacts;
using ContactManager.Application.Commands.GetContactById;

namespace ContactManager.WebApi.Extensions
{
    public static class MediatRServiceExtensions
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateContactCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RemoveContactCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateContactCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllContactsQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetContactByIdQuery).Assembly);
            });

            return services;
        }
    }
}
