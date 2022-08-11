using AutoMapper;
using FAQs.Data.DTOs;
using FAQs.Data.Entities;

namespace FAQs.Common.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<ApiUser, UserDto>().ReverseMap();
        CreateMap<ApiUser, LoginUserDto>().ReverseMap();
        CreateMap<ApiUser, GetUsersDto>().ReverseMap();
    }
}