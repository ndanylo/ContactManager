using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.UpdateContact
{
    public class UpdateContactCommand  : IRequest<Result>
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public bool IsMarried { get; set; }
        public string Phone  { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}