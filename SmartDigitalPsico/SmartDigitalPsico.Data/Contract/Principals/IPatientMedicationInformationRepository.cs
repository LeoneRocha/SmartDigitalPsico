using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientMedicationInformationRepository : IRepositoryEntityBaseSimple<PatientMedicationInformation>
    { 
        Task<List<PatientMedicationInformation>> FindAllByPatient(long patientId);
    }
}
