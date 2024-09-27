using ContactManager.Domain.Abstractions;
using ContactManager.Domain.Entities;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result>
    {
        private readonly IWriteRepository<Person, long> _repository;

        public UpdateContactCommandHandler(IWriteRepository<Person, long> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
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

            var updateResult = await _repository.UpdateAsync(personResult.Value, request.Id);
            if(updateResult.IsSuccess)
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

            return Result.Failure(updateResult.Error);
        }
    }
}