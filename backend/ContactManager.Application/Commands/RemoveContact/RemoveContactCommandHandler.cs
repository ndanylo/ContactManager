using ContactManager.Domain.Abstractions;
using ContactManager.Domain.Entities;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.RemoveContact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, Result>
    {
        private readonly IWriteRepository<Person, long> _repository;

        public RemoveContactCommandHandler(IWriteRepository<Person, long> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var deleteResult = await _repository.RemoveAsync(request.Id);
            if(deleteResult.IsSuccess)
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
            
            return Result.Failure(deleteResult.Error);
        }
    }
}