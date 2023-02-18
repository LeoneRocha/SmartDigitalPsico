using AutoMapper;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;

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

            #region Patient
            CreateMap<Patient, GetPatientVO>();
            CreateMap<GetPatientVO, Patient>();
            CreateMap<AddPatientVO, Patient>();
            CreateMap<UpdatePatientVO, Patient>();

            #endregion Patient 

            #region PatientRecord
            CreateMap<PatientRecord, GetPatientRecordVO>();
            CreateMap<GetPatientRecordVO, PatientRecord>();
            CreateMap<AddPatientRecordVO, PatientRecord>();
            CreateMap<UpdatePatientRecordVO, PatientRecord>();

            #endregion PatientRecord 

            #region PatientAdditionalInformation
            CreateMap<PatientAdditionalInformation, GetPatientAdditionalInformationVO>();
            CreateMap<GetPatientAdditionalInformationVO, PatientAdditionalInformation>();
            CreateMap<AddPatientAdditionalInformationVO, PatientAdditionalInformation>();
            CreateMap<UpdatePatientAdditionalInformationVO, PatientAdditionalInformation>();

            #endregion PatientAdditionalInformation 

            #region PatientHospitalizationInformation
            CreateMap<PatientHospitalizationInformation, GetPatientHospitalizationInformationVO>();
            CreateMap<GetPatientHospitalizationInformationVO, PatientHospitalizationInformation>();
            CreateMap<AddPatientHospitalizationInformationVO, PatientHospitalizationInformation>();
            CreateMap<UpdatePatientHospitalizationInformationVO, PatientHospitalizationInformation>();

            #endregion PatientHospitalizationInformation 

            #region PatientMedicationInformation
            CreateMap<PatientMedicationInformation, GetPatientMedicationInformationVO>();
            CreateMap<GetPatientMedicationInformationVO, PatientMedicationInformation>();
            CreateMap<AddPatientMedicationInformationVO, PatientMedicationInformation>();
            CreateMap<UpdatePatientMedicationInformationVO, PatientMedicationInformation>();

            #endregion PatientMedicationInformation 

            #region PatientNotificationMessage
            CreateMap<PatientNotificationMessage, GetPatientNotificationMessageVO>();
            CreateMap<GetPatientNotificationMessageVO, PatientNotificationMessage>();
            CreateMap<AddPatientNotificationMessageVO, PatientNotificationMessage>();
            CreateMap<UpdatePatientNotificationMessageVO, PatientNotificationMessage>();

            #endregion PatientNotificationMessage 
        }
    }
}