using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class RoleGroupRepository : GenericRepositoryEntityBaseSimple<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(SmartDigitalPsicoDataContext context) : base(context) { }
    }
}
