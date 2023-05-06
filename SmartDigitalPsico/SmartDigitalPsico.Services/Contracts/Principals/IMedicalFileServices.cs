using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IMedicalFileServices : IGenericServicesEntityBaseSimple<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO>
    { 
        Task<bool> PostFileAsync(AddMedicalFileVOService entity);
         
        Task<bool> DownloadFileById(long fileID);

        Task<ServiceResponse<List<GetMedicalFileVO>>> FindAllByMedical(long medicalId);
    }
}