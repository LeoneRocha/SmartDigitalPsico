using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Business.Generic.Contracts
{
    public interface IGenericBusinessEntityBaseSimple<T, ResutEntity> where T : EntityBaseSimple
        where ResutEntity : class
    {
        Task<ServiceResponse<ResutEntity>> Create(ResutEntity item);
        Task<ServiceResponse<ResutEntity>> FindByID(long id);
        Task<ServiceResponse<List<ResutEntity>>> FindAll();
        Task<ServiceResponse<ResutEntity>> Update(ResutEntity item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> Exists(long id);
        Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);
        Task<ServiceResponse<bool>> EnableOrDisable(long id);
      

    }
}