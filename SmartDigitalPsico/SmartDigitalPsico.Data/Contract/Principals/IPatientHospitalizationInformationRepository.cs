using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientHospitalizationInformationRepository : IRepositoryEntityBaseSimple<PatientHospitalizationInformation>
    { 
        Task<List<PatientHospitalizationInformation>> FindAllByPatient(long patientId);
    }
}
