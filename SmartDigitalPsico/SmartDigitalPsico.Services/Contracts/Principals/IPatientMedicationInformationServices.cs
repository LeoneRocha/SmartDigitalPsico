using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientMedicationInformationServices : IGenericServicesEntityBaseSimple<PatientMedicationInformation, GetPatientMedicationInformationVO>
    {
        Task<ServiceResponse<GetPatientMedicationInformationVO>> Create(AddPatientMedicationInformationVO item);
        Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAllByPatient(long patientId);
    }
}