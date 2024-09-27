using AutoMapper;
using ContactManager.Application.ViewModels;
using ContactManager.Domain.Abstractions;
using ContactManager.Infrastructure.Persistence.Read.Models;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.GetAllContacts
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, Result<List<PersonViewModel>>>
    {
        private readonly IReadRepository<PersonReadModel, long> _repository;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(
            IReadRepository<PersonReadModel, long> repository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<List<PersonViewModel>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var getAllContactsResult = await _repository.GetAllAsync();
            if(getAllContactsResult.IsFailure)
            {
                return Result.Failure<List<PersonViewModel>>(getAllContactsResult.Error);
            }
            
            try
            {
                var viewModels = _mapper.Map<List<PersonViewModel>>(getAllContactsResult.Value.ToList());
                return Result.Success(viewModels);
            }
            catch(Exception ex)
            {
                return Result.Failure<List<PersonViewModel>>(ex.Message);
            }
        }
    }
}