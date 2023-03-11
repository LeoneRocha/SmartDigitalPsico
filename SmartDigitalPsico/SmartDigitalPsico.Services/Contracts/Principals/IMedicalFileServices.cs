using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IMedicalFileServices : IGenericServicesEntityBaseSimpleV2<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO>
    { 
        Task<bool> PostFileAsync(AddMedicalFileVOService entity);
         
        Task<bool> DownloadFileById(long fileID); 
    }
}