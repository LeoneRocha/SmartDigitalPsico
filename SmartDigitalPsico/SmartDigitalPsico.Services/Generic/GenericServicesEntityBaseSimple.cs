using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Generic
{
    public class GenericServicesEntityBaseSimple<TEntity, TEntityAdd, TEntityUpdate, TEntityResult, Business>
        : IGenericServicesEntityBaseSimple<TEntity, TEntityAdd, TEntityUpdate, TEntityResult>
        where TEntity : EntityBaseSimple
        where TEntityAdd : IEntityVOAdd
        where TEntityUpdate : IEntityVO
        where TEntityResult : class 
        where Business : IGenericBusinessEntityBaseSimple<TEntity, TEntityAdd, TEntityUpdate, TEntityResult>
        

    {
        private readonly IMapper _mapper;
        private readonly Business _genericBusiness;
        protected long UserId { get; private set; }
        public GenericServicesEntityBaseSimple(IMapper mapper, Business genericBusiness)
        {
            _mapper = mapper;
            _genericBusiness = genericBusiness;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Create(TEntityAdd item)
        {
            var serviceResponse = new ServiceResponse<TEntityResult>();

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
        public async Task<ServiceResponse<List<TEntityResult>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<TEntityResult>>();

            serviceResponse = await _genericBusiness.FindAll();

            return serviceResponse;
        }
        public async Task<ServiceResponse<TEntityResult>> FindByID(long id)
        {
            var serviceResponse = new ServiceResponse<TEntityResult>();

            serviceResponse = await _genericBusiness.FindByID(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<TEntityResult>>> FindWithPagedSearch(string query)
        {
            var serviceResponse = new ServiceResponse<List<TEntityResult>>();

            serviceResponse = await _genericBusiness.FindWithPagedSearch(query);

            return serviceResponse;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            var serviceResponse = new ServiceResponse<int>();

            serviceResponse = await _genericBusiness.GetCount(query);

            return serviceResponse;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Update(TEntityUpdate item)
        {
            var serviceResponse = new ServiceResponse<TEntityResult>();

            serviceResponse = await _genericBusiness.Update(item);

            return serviceResponse;
        }
        public void SetUserId(long id)
        {
            this.UserId = id;
            _genericBusiness.SetUserId(id);
        }
    }
}