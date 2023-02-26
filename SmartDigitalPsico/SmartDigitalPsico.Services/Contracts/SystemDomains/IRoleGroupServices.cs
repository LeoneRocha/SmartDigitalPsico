using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface IRoleGroupServices : IGenericServicesEntityBaseSimpleV2<RoleGroup, AddRoleGroupVO, UpdateRoleGroupVO, GetRoleGroupVO>
    {

    }
}