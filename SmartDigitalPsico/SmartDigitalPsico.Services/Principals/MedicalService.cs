using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;
using System.ComponentModel;
using System.Security.Claims;
using SmartDigitalPsico.Model.VO.Medical;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalService : GenericServicesEntityBase<Medical, IMedicalBusiness, GetMedicalVO>, IMedicalService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public MedicalService(IMapper mapper, IMedicalBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
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