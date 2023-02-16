using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Bussines.Generic.Contracts
{
    public interface IGenericBussinesEntityBase<T, ResutEntity> where T : EntityBase
        where ResutEntity : EntityDTOBase
    {
        Task<ServiceResponse<ResutEntity>> Create(ResutEntity item);
        Task<ServiceResponse<ResutEntity>> FindByID(long id);
        Task<ServiceResponse<List<ResutEntity>>> FindAll();
        Task<ServiceResponse<ResutEntity>> Update(ResutEntity item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> Exists(long id);
        Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);

    }
}