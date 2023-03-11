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
        private readonly IMapper _mapper;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public MedicalFileServices(IMapper mapper, IMedicalFileBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _mapper = mapper;
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DownloadFileById(long fileId)
        {
            try
            { 
                return await _entityBusiness.DownloadFileById(fileId); 
            }
            catch (Exception)
            {
                throw;
            } 
            return false;
        }

      
        public async Task<bool> PostFileAsync(AddMedicalFileVOService entity)
        {
            try
            {
                AddMedicalFileVO entityAdd = _mapper.Map<AddMedicalFileVO>(entity);
                entityAdd.IdUserAction = 1;//>>>>>>>>_httpContextAccessor 
                return await _entityBusiness.PostFileAsync(entityAdd); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}