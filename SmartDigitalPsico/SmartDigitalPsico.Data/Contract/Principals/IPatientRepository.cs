using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientRepository : IRepositoryEntityBase<Patient>
    {
        Task<List<Patient>> FindAllByMedicalId(long medicalId);
        Task<Patient> FindByEmail(string value);
        Task<Patient> FindByPatient(Patient info);
    }
}
