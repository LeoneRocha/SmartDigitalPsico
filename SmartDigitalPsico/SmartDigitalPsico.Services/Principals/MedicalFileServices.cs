using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Utils;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;
using System.IO;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalFileServices : GenericServicesEntityBaseSimpleV2<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileBusiness>, IMedicalFileServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalFileBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public MedicalFileServices(IMapper mapper, IMedicalFileBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DownloadFileById(long fileId)
        {
            try
            {
                var file = await _entityBusiness.FindByID(fileId);

                if (file.Data != null) {
                    var content = new System.IO.MemoryStream(file?.Data?.FileData);

                    var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "ResourcesTemp",
                       file?.Data?.Description);

                    await copyStream(content, path);

                    return true;
                } 
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        private async Task copyStream(MemoryStream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public async Task<bool> PostFileAsync(AddMedicalFileVOUpload entity)
        {
            try
            { 
                return await _entityBusiness.PostFileAsync(entity);

                //var result = dbContextClass.FileDetails.Add(fileDetails);
                //await dbContextClass.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}