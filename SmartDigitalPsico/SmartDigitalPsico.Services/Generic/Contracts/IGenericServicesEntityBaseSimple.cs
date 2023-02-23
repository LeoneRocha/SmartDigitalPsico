using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Services.Generic.Contracts
{
    public interface IGenericServicesEntityBaseSimple<T, ResultEntity> where T : EntityBaseSimple
        where ResultEntity : class
    {
        Task<ServiceResponse<ResultEntity>> Create(ResultEntity item);
        Task<ServiceResponse<ResultEntity>> FindByID(long id);
        Task<ServiceResponse<List<ResultEntity>>> FindAll();
        Task<ServiceResponse<ResultEntity>> Update(ResultEntity item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> EnableOrDisable(long id);
        Task<ServiceResponse<bool>> Exists(long id);
        Task<ServiceResponse<List<ResultEntity>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);

    }
}