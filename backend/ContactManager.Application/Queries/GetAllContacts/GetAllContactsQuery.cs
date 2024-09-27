using ContactManager.Application.ViewModels;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.GetAllContacts
{
    public class GetAllContactsQuery : IRequest<Result<List<PersonViewModel>>> {   }
}
