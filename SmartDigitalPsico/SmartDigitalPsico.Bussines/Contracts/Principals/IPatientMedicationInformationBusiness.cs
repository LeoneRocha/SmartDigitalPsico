using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientMedicationInformationBusiness 
        : IGenericBusinessEntityBaseSimpleV2<PatientMedicationInformation, AddPatientMedicationInformationVO, UpdatePatientMedicationInformationVO, GetPatientMedicationInformationVO>
    { 
        Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAllByPatient(long patientId);
    }
}