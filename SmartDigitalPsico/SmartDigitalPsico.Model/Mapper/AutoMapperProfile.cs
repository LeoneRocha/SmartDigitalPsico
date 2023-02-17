using AutoMapper;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO;

namespace SmartDigitalPsico.Model.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region USER
            CreateMap<User, GetUserVO>();
            CreateMap<GetUserVO, User>();
            CreateMap<UserRegisterVO, User>();
            #endregion

            #region EntityBase

            CreateMap<EntityBaseSimple, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, EntityBaseSimple>();

            #endregion
             
            #region Gender
            CreateMap<Gender, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Gender>();

            CreateMap<Gender, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, Gender>();
            #endregion 
        }
    }
}