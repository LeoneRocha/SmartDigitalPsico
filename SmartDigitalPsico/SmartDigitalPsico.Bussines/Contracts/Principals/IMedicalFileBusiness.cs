using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalFileBusiness : IGenericBusinessEntityBaseSimple<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO>
    {
        Task<GetMedicalFileVO> DownloadFileById(long fileId);
        Task<bool> PostFileAsync(AddMedicalFileVO entity);

        Task<ServiceResponse<List<GetMedicalFileVO>>> FindAllByMedical(long medicalId);
    }
}