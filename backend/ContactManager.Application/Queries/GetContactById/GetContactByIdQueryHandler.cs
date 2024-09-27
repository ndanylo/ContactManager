using AutoMapper;
using ContactManager.Application.ViewModels;
using ContactManager.Domain.Abstractions;
using ContactManager.Infrastructure.Persistence.Read.Models;
using CSharpFunctionalExtensions;
using MediatR;

namespace ContactManager.Application.Commands.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Result<PersonViewModel>>
    {
        private readonly IReadRepository<PersonReadModel, long> _repository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(
            IReadRepository<PersonReadModel, long> repository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<PersonViewModel>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var getContactResult = await _repository.GetAsync(request.Id);
            if(getContactResult.IsFailure)
            {
                return Result.Failure<PersonViewModel>(getContactResult.Error);
            }

            var contact = getContactResult.Value;
            if(contact == null)
            {
                return Result.Failure<PersonViewModel>("Contact with this id wasn`t found");
            }

            return Result.Success(contact != null ? _mapper.Map<PersonViewModel>(contact) : new PersonViewModel());
        }
    }
}