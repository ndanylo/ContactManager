using AutoMapper;
using ContactManager.Infrastructure.Persistence.Read.Models;
using ContactManager.Application.ViewModels;
using ContactManager.Domain.ValueObjects;

namespace ContactManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonReadModel, PersonViewModel>()
                .ForMember(dest => dest.isMarried, opt => 
                    opt.MapFrom(src => src.MarriageStatus == MarriageStatus.Married));
        }
    }
}
