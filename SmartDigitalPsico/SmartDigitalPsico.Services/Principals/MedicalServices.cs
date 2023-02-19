using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalServices: GenericServicesEntityBase<Medical, IMedicalBusiness, GetMedicalVO>, IMedicalServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public MedicalServices(IMapper mapper, IMedicalBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item)
        {
            var serviceResponse = new ServiceResponse<GetMedicalVO>();

            // item.IdUserAction = GetUserId();

            serviceResponse = await _entityBusiness.Create(item);

            return serviceResponse;
        }
    }
}