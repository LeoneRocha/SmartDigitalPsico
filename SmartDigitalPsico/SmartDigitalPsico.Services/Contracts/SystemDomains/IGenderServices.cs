using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Generic;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface IGenderServices 
        : IGenericServicesEntityBaseSimple<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO>
    {

    }
}