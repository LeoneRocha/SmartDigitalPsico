using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientRecordRepository : IRepositoryEntityBaseSimple<PatientRecord>
    { 
        Task<List<PatientRecord>> FindAllByPatient(long patientId);
    }
}
