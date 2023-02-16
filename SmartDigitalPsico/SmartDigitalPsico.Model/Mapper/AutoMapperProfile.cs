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
            #region USER
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<UserRegisterDto, User>();
            #endregion

            #region EntityBase

            CreateMap<EntityBaseSimple, EntityDTOBaseSimple>();
            CreateMap<EntityDTOBaseSimple, EntityBaseSimple>();

            #endregion
             
            #region Gender
            CreateMap<Gender, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Gender>();

            CreateMap<Gender, EntityDTOBaseSimple>();
            CreateMap<EntityDTOBaseSimple, Gender>();
            #endregion 
        }
    }
}