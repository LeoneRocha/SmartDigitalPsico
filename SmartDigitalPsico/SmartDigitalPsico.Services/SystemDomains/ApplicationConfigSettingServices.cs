using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.SystemDomains
{ 
    public class ApplicationConfigSettingServices : 
        GenericServicesEntityBaseSimple<ApplicationConfigSetting, AddApplicationConfigSettingVO, UpdateApplicationConfigSettingVO, GetApplicationConfigSettingVO, IApplicationConfigSettingBusiness>, IApplicationConfigSettingServices

    {
        private readonly IApplicationConfigSettingBusiness _entityBusiness;

        public ApplicationConfigSettingServices(IMapper mapper, IApplicationConfigSettingBusiness entityBusiness)
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