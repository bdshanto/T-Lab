using AutoMapper;
using TLabApp.Application.Models;
using TLabApp.Domain.Entities;

namespace TLabApp.Application.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

         CreateMap<PersonDto, Person>().ReverseMap();
         CreateMap<SkillPersonMapDto, SkillPersonMap>().ReverseMap();
    }
}