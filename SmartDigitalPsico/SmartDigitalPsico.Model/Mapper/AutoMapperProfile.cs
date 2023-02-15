using AutoMapper;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Model.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}