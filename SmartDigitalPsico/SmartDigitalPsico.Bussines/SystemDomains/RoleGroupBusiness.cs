using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class RoleGroupBusiness : GenericBusinessEntityBaseSimple<RoleGroup,AddRoleGroupVO, GetRoleGroupVO, GetRoleGroupVO,IRoleGroupRepository>, IRoleGroupBusiness

    {
        public RoleGroupBusiness(IMapper _mapper, IRoleGroupRepository entityRepository)
            : base(_mapper, entityRepository) { }
    }
}