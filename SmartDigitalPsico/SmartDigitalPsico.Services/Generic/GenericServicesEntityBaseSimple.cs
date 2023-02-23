using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Services.Generic
{
    public class GenericServicesEntityBaseSimple<Entity, Business, EntityVO>
        : IGenericBusinessEntityBaseSimple<Entity, EntityVO>
        where Entity : EntityBaseSimple
        where Business : IGenericBusinessEntityBaseSimple<Entity, EntityVO>
        where EntityVO : class

    {
        private readonly IMapper _mapper;
        private readonly Business _genericBusiness;
        public GenericServicesEntityBaseSimple(IMapper mapper, Business genericBusiness)
        {
            _mapper = mapper;
            _genericBusiness = genericBusiness;
        }
        public virtual async Task<ServiceResponse<EntityVO>> Create(EntityVO item)
        {
            var serviceResponse = new ServiceResponse<EntityVO>();

            serviceResponse = await _genericBusiness.Create(item);

            return serviceResponse;

        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBusiness.Delete(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> EnableOrDisable(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBusiness.EnableOrDisable(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Exists(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBusiness.Exists(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<EntityVO>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<EntityVO>>();

            serviceResponse = await _genericBusiness.FindAll();

            return serviceResponse;
        }
        public async Task<ServiceResponse<EntityVO>> FindByID(long id)
        {
            var serviceResponse = new ServiceResponse<EntityVO>();

            serviceResponse = await _genericBusiness.FindByID(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<EntityVO>>> FindWithPagedSearch(string query)
        {
            var serviceResponse = new ServiceResponse<List<EntityVO>>();

            serviceResponse = await _genericBusiness.FindWithPagedSearch(query);

            return serviceResponse;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            var serviceResponse = new ServiceResponse<int>();

            serviceResponse = await _genericBusiness.GetCount(query);

            return serviceResponse;
        }
        public virtual async Task<ServiceResponse<EntityVO>> Update(EntityVO item)
        {
            var serviceResponse = new ServiceResponse<EntityVO>();

            serviceResponse = await _genericBusiness.Update(item);

            return serviceResponse;
        }
    }
}