using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;
using System.Security.Claims;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Model.VO;

namespace SmartDigitalPsico.Services.SystemDomains
{
    // public class  : GenericServicesEntityBaseSimple<, IGenderBusiness, EntityVOBaseSimple>, IGenderService
    public class GenderService : GenericServicesEntityBaseSimple<Gender, IGenderBusiness, EntityVOBaseSimple>, IGenderServices

    {
        private readonly IGenderBusiness _entityBusiness;

        public GenderService(IMapper mapper, IGenderBusiness entityBusiness)
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