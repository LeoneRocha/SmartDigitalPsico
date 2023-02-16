using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Security.Claims;

namespace SmartDigitalPsico.Services.Principals
{
    public class GenderService : IGenderServices
    {
        private readonly IGenderBussines _genderBussines;

        public GenderService(IGenderBussines genderService)
        {
            _genderBussines = genderService;
        } 
        public Task<ServiceResponse<EntityDTOBaseSimple>> Create(EntityDTOBaseSimple item)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> Exists(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<EntityDTOBaseSimple>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<EntityDTOBaseSimple>>();

            serviceResponse = await _genderBussines.FindAll();

            return serviceResponse;
        }

        public Task<ServiceResponse<EntityDTOBaseSimple>> FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EntityDTOBaseSimple>>> FindWithPagedSearch(string query)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> GetCount(string query)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<EntityDTOBaseSimple>> Update(EntityDTOBaseSimple item)
        {
            throw new NotImplementedException();
        }
    }
}