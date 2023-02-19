using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic;
using System.Security.Claims;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Model.VO.Domains;

namespace SmartDigitalPsico.Services.SystemDomains
{
    // public class  : GenericServicesEntityBaseSimple<, IGenderBusiness, EntityVOBaseSimple>, IGenderService
    public class RoleGroupServices : GenericServicesEntityBaseSimple<RoleGroup, IRoleGroupBusiness, GetRoleGroupVO>, IRoleGroupServices

    {
        private readonly IRoleGroupBusiness _entityBusiness;

        public RoleGroupServices(IMapper mapper, IRoleGroupBusiness entityBusiness)
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