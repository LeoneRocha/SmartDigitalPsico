using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientFileBusiness : IGenericBusinessEntityBaseSimple<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO>
    {
        Task<GetPatientFileVO> DownloadFileById(long fileId);
        Task<bool> PostFileAsync(AddPatientFileVO entity);
    }
}