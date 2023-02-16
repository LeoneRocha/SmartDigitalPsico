using SmartDigitalPsico.Bussines.Contracts.Generic;
using SmartDigitalPsico.Bussines.Generic;
using SmartDigitalPsico.Data.Contract.Generic;
using SmartDigitalPsico.Data.Contract.SystemDomains;
using SmartDigitalPsico.Data.Repository.SystemDomains;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IGenderServices
    {
        Task<ServiceResponse<EntityDTOBaseSimple>> Create(EntityDTOBaseSimple item);
        Task<ServiceResponse<EntityDTOBaseSimple>> FindByID(long id);
        Task<ServiceResponse<List<EntityDTOBaseSimple>>> FindAll();
        Task<ServiceResponse<EntityDTOBaseSimple>> Update(EntityDTOBaseSimple item);
        Task<ServiceResponse<bool>> Delete(long id);
        Task<ServiceResponse<bool>> Exists(long id);

        Task<ServiceResponse<List<EntityDTOBaseSimple>>> FindWithPagedSearch(string query);
        Task<ServiceResponse<int>> GetCount(string query);
    }
}