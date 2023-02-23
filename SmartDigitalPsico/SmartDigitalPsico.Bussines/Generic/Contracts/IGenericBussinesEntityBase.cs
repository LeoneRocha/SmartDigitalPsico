using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;

namespace SmartDigitalPsico.Business.Generic.Contracts
{
    public interface IGenericBusinessEntityBase<TEntity, TAddEntity, TUpdateEntity, ResultEntity>
        where TEntity : EntityBaseSimple
        where TAddEntity : class
        where TUpdateEntity : IEntityVO
        where ResultEntity : class
    {
        Task<ServiceResponse<ResultEntity>> Create(TAddEntity item);
        Task<ServiceResponse<ResultEntity>> FindByID(long id);
        Task<ServiceResponse<List<ResultEntity>>> FindAll();
        Task<ServiceResponse<ResultEntity>> Update(TUpdateEntity item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> EnableOrDisable(long id);
        Task<ServiceResponse<bool>> Exists(long id);
        Task<ServiceResponse<List<ResultEntity>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);

    }
}