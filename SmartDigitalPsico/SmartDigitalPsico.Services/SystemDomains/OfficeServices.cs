using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.SystemDomains
{
    // public class  : GenericServicesEntityBaseSimple<, IOfficeBusiness, EntityVOBaseSimple>, IOfficeService
    public class OfficeServices : GenericServicesEntityBaseSimple<Office, IOfficeBusiness, EntityVOBaseSimple>, IOfficeServices

    {
        private readonly IOfficeBusiness _entityBusiness;

        public OfficeServices(IMapper mapper, IOfficeBusiness entityBusiness)
           : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
        }

        /* public async Task<ServiceResponse<List<EntityVOBaseSimple>>> FindAll()
         {
             var serviceResponse = new ServiceResponse<List<EntityVOBaseSimple>>();

             serviceResponse = await _entityBusiness.FindAll();

             return serviceResponse;
         } */
    }
}