using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

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

    }
}