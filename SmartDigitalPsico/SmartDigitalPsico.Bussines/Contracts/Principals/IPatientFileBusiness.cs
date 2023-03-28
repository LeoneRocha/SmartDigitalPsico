using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientFileBusiness : IGenericBusinessEntityBaseSimple<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO>
    {
        Task<bool> DownloadFileById(long fileId);
        Task<bool> PostFileAsync(AddPatientFileVO entity);
    }
}