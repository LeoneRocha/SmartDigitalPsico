using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface IGenderServices 
        : IGenericServicesEntityBaseSimpleV2<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO>
    {

    }
}