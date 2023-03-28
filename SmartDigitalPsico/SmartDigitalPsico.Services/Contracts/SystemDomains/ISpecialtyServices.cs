using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface ISpecialtyServices : IGenericServicesEntityBaseSimple<Specialty, AddSpecialtyVO, UpdateSpecialtyVO, GetSpecialtyVO>
    {

    }
}