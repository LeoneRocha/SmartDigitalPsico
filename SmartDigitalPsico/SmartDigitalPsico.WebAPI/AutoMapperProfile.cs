using AutoMapper;
using SmartDigitalPsico.WebAPI.Dtos.User;
using SmartDigitalPsico.WebAPI.Models;

namespace SmartDigitalPsico.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<User, GetUserDto>();
        }
    }
}