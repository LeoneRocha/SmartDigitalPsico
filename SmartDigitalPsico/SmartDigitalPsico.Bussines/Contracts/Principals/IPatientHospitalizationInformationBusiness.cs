using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientHospitalizationInformationBusiness : IGenericBusinessEntityBaseSimple<PatientHospitalizationInformation, GetPatientHospitalizationInformationVO>
    {
        Task<ServiceResponse<GetPatientHospitalizationInformationVO>> Create(AddPatientRecordVO item);
        Task<List<GetPatientHospitalizationInformationVO>> FindAllByPatient(long patientId);
    }
}