using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IMedicalFileRepository : IRepositoryEntityBaseSimple<MedicalFile>
    {
        Task<List<MedicalFile>> FindAllByMedical(long medicalId);
    }
}
