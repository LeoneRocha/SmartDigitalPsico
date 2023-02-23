using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.SystemDomains
{
    // public class  : GenericServicesEntityBaseSimple<, IGenderBusiness, EntityVOBaseSimple>, IGenderService
    public class GenderServices : 
        GenericServicesEntityBaseSimpleV2<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderBusiness>, IGenderServices

    {
        private readonly IGenderBusiness _entityBusiness;

        public GenderServices(IMapper mapper, IGenderBusiness entityBusiness)
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