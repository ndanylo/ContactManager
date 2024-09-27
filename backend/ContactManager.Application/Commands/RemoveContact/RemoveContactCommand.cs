using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.RemoveContact
{
    public class RemoveContactCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}