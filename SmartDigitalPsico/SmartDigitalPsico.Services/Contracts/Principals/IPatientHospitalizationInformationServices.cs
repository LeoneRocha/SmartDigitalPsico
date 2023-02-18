using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientHospitalizationInformationServices : IGenericServicesEntityBaseSimple<PatientHospitalizationInformation, GetPatientHospitalizationInformationVO>
    {
        Task<ServiceResponse<GetPatientHospitalizationInformationVO>> Create(AddPatientHospitalizationInformationVO item);
        Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId);
    }
}