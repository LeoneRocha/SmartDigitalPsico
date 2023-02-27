using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientFileRepository : IRepositoryEntityBaseSimple<PatientFile>
    {
        Task<PatientFile> FindByPatient(PatientFile info);
    }
}
