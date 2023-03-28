using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalServices
        : GenericServicesEntityBase<Medical, AddMedicalVO, UpdateMedicalVO, GetMedicalVO, IMedicalBusiness>, IMedicalServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalBusiness _entityBusiness; 
        public MedicalServices(IMapper mapper, 
            IMedicalBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        } 
    }
}