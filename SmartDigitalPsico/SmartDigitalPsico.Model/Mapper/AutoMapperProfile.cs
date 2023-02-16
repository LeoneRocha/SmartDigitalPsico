using AutoMapper;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Domains;
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


            CreateMap<EntityBaseSimple, EntityDTOBaseSimple>();
            CreateMap<EntityDTOBaseSimple, EntityBaseSimple>();
            
            CreateMap<Gender, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Gender>();

            CreateMap<Gender, EntityDTOBaseSimple>();
            CreateMap<EntityDTOBaseSimple, Gender>();


        }
    }
}