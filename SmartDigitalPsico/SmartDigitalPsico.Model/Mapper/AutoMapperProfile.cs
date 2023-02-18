using AutoMapper;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;

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
            CreateMap<Gender, GetGenderVO>();
            CreateMap<GetGenderVO, Gender>(); 

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
            CreateMap<UpdateUserVO, User>();  
            CreateMap<UserLoginVO, User>();
            CreateMap<UserRegisterVO, User>();
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