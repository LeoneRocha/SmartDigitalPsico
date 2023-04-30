using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.SystemDomains
{
    public interface IRoleGroupRepository : IRepositoryEntityBaseSimple<RoleGroup>
    {
        Task<List<RoleGroup>> FindByIDs(List<long>? roleGroupsIds);
    }
}
