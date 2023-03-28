using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.SystemDomains
{
     public class GenderServices : 
        GenericServicesEntityBaseSimple<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderBusiness>, IGenderServices

    {
        private readonly IGenderBusiness _entityBusiness;

        public GenderServices(IMapper mapper, IGenderBusiness entityBusiness)
           : base(mapper, entityBusiness)
        { 
            _entityBusiness = entityBusiness;
        } 
    }
}