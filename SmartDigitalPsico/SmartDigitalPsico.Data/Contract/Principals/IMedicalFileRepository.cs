using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IMedicalFileRepository : IRepositoryEntityBaseSimple<MedicalFile>
    {
        Task<MedicalFile> FindByPatient(MedicalFile info);
    }
}
