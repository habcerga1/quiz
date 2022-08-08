using AutoMapper;
using Domain.Dto;
using Domain.Models.Base;

namespace Infrastructure.Mappers;


public class MappingProfiler : Profile
{
    public MappingProfiler()
    {
        CreateMap<RegistrationDto, User>()
            .ConstructUsing(parent => new User())
            .ForMember(target => target.FullName,
                action => action.MapFrom(source => $"{source.FirstName} {source.LastName}"))
            .ForMember(target => target.Email, action => action.MapFrom(source => source.Email));
    }
}