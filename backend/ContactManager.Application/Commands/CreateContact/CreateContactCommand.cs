using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public bool IsMarried { get; set; }
        public string Phone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}