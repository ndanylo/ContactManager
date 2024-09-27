using ContactManager.Application.ViewModels;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.GetContactById
{
    public class GetContactByIdQuery : IRequest<Result<PersonViewModel>>
    {
        public long Id { get;  set;}
    }
}