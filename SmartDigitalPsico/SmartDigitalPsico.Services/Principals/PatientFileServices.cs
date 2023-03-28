using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientFileServices : GenericServicesEntityBaseSimple<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO, IPatientFileBusiness>, IPatientFileServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientFileBusiness _entityBusiness;
        private readonly IMapper _mapper;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientFileServices(IMapper mapper, IPatientFileBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
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
        public async Task<bool> PostFileAsync(AddPatientFileVOService entity)
        {
            try
            {
                AddPatientFileVO entityAdd = _mapper.Map<AddPatientFileVO>(entity);  
                return await _entityBusiness.PostFileAsync(entityAdd); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}