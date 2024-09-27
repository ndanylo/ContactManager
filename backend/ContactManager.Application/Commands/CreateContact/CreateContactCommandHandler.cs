using ContactManager.Domain.Abstractions;
using ContactManager.Domain.Entities;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result>
    {
        private readonly IWriteRepository<Person, long> _repository;

        public CreateContactCommandHandler(IWriteRepository<Person, long> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var personResult = Person.Create(
                request.Name, 
                request.Birthday, 
                request.IsMarried, 
                request.Phone, 
                request.Salary
            );
            if (personResult.IsFailure)
            {
                return Result.Failure(personResult.Error);
            }

            var addContactResult = await _repository.AddAsync(personResult.Value);
            if(addContactResult.IsSuccess)
            {
                try
                {
                    await _repository.SaveChangesAsync();
                    return Result.Success();
                }
                catch(Exception ex)
                {
                    return Result.Failure(ex.Message);
                }
            }
            return Result.Failure(addContactResult.Error);
        }
    }
}