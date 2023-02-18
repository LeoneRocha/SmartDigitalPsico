using AutoMapper;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Model.VO.Medical;

namespace SmartDigitalPsico.Model.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region EntityBase

            CreateMap<EntityBaseSimple, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, EntityBaseSimple>();

            #endregion

            #region Gender
            CreateMap<Gender, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Gender>();

            CreateMap<Gender, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, Gender>();
            #endregion  Gender

            #region Office
            CreateMap<Office, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Office>();

            CreateMap<Office, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, Office>();
            #endregion Office

            #region RoleGroup
            CreateMap<RoleGroup, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, RoleGroup>();

            CreateMap<RoleGroup, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, RoleGroup>();
            #endregion RoleGroup

            #region Specialty
            CreateMap<Specialty, EntityBaseSimple>();
            CreateMap<EntityBaseSimple, Specialty>();

            CreateMap<Specialty, EntityVOBaseSimple>();
            CreateMap<EntityVOBaseSimple, Specialty>();
            #endregion Specialty
             
            #region USER
            CreateMap<User, GetUserVO>();
            CreateMap<GetUserVO, User>();
            CreateMap<UserRegisterVO, User>();
            CreateMap<UpdateUserVO, User>();
            #endregion USER

            #region Medical
            CreateMap<Medical, GetMedicalVO>();
            CreateMap<GetMedicalVO, Medical>();
            CreateMap<AddMedicalVO, Medical>();
            CreateMap<UpdateMedicalVO, Medical>();

            #endregion Medical 

            //TODO:Patient
            //TODO:PatientRecord
            //TODO:PatientAdditionalInformation
            //TODO:PatientHospitalizationInformation
            //TODO:PatientMedicationInformation
            //TODO:PatientNotificationMessage
        }
    }
}