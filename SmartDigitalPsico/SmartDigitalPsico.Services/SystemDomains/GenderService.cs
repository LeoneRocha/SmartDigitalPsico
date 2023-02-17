using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;
using System.Security.Claims;

namespace SmartDigitalPsico.Services.Principals
{
   // public class  : GenericServicesEntityBaseSimple<, IGenderBusiness, EntityDTOBaseSimple>, IGenderService
   public class GenderService : GenericServicesEntityBaseSimple <Gender, IGenderBusiness, EntityDTOBaseSimple>, IGenderServices

    {
        private readonly IGenderBusiness _entityBusiness;

        public GenderService(IMapper mapper, IGenderBusiness entityBusiness)
           : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
        }

        /* public async Task<ServiceResponse<List<EntityDTOBaseSimple>>> FindAll()
         {
             var serviceResponse = new ServiceResponse<List<EntityDTOBaseSimple>>();

             serviceResponse = await _entityBusiness.FindAll();

             return serviceResponse;
         } */
    }
}