using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientFileServices : IGenericServicesEntityBaseSimpleV2<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO>
    {
        Task<bool> PostFileAsync(AddPatientFileVOService entity);

        Task<bool> DownloadFileById(long fileID);
    }
}