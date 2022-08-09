using AutoMapper;
using Domain.Dto;
using Domain.Models.Base;

namespace Infrastructure.Mappers;


public class MappingProfiler1 : Profile
{
    public MappingProfiler1()
    {
        CreateMap<RegistrationDto, User>()
            .ForMember(target => target.Email, act => act.MapFrom(s => s.Email))
            .ForMember(target => target.UserName, act => act.MapFrom(s => s.Email));
    }
}