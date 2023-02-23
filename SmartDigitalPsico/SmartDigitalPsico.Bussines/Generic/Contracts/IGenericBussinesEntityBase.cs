using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Business.Generic.Contracts
{
    public interface IGenericBusinessEntityBase<T, EntityVO> where T : EntityBase
        where EntityVO : class
    {
        Task<ServiceResponse<EntityVO>> Create(EntityVO item);
        Task<ServiceResponse<EntityVO>> FindByID(long id);
        Task<ServiceResponse<List<EntityVO>>> FindAll();
        Task<ServiceResponse<EntityVO>> Update(EntityVO item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> EnableOrDisable(long id);
        Task<ServiceResponse<bool>> Exists(long id);
        Task<ServiceResponse<List<EntityVO>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);

    }
}