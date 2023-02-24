using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Domains;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface IOfficeServices : IGenericServicesEntityBaseSimpleV2<Office, AddOfficeVO, UpdateOfficeVO, GetOfficeVO>
    {

    }
}