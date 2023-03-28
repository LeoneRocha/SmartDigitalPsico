using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;

namespace SmartDigitalPsico.Business.Contracts.SystemDomains
{
    public interface IOfficeBusiness : IGenericBusinessEntityBaseSimple<Office, AddOfficeVO, UpdateOfficeVO, GetOfficeVO>
    {

    }
}