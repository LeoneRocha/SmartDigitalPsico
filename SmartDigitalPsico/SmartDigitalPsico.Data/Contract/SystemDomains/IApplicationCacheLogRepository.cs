using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.SystemDomains
{
    public interface IApplicationCacheLogRepository : IRepositoryEntityBaseSimple<ApplicationCacheLog>
    {
        Task<bool> Delete(string cacheKey);
    }
}
