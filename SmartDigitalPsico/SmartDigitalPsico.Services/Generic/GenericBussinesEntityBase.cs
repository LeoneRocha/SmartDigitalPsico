using AutoMapper;
using SmartDigitalPsico.Bussines.Generic.Contracts;
using SmartDigitalPsico.Data.Repository.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Generic
{
    public class GenericServicesEntityBase<Entity, Bussines, ResutEntity>
        : IGenericBussinesEntityBase<Entity, ResutEntity>
        where Entity : EntityBase
        where Bussines : IGenericBussinesEntityBase<Entity, ResutEntity>
        where ResutEntity : EntityDTOBase

    {
        private readonly IMapper _mapper;
        private readonly Bussines _genericBussines;
        public GenericServicesEntityBase(IMapper mapper, Bussines genericBussines)
        {
            _mapper = mapper;
            _genericBussines = genericBussines;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Create(ResutEntity item)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

            serviceResponse = await _genericBussines.Create(item);

            return serviceResponse;

        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBussines.Delete(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> EnableOrDisable(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBussines.Delete(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Exists(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _genericBussines.Exists(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<ResutEntity>>();

            serviceResponse = await _genericBussines.FindAll();

            return serviceResponse;
        }
        public async Task<ServiceResponse<ResutEntity>> FindByID(long id)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

            serviceResponse = await _genericBussines.FindByID(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query)
        {
            var serviceResponse = new ServiceResponse<List<ResutEntity>>();

            serviceResponse = await _genericBussines.FindWithPagedSearch(query);

            return serviceResponse;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            var serviceResponse = new ServiceResponse<int>();

            serviceResponse = await _genericBussines.GetCount(query);

            return serviceResponse;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Update(ResutEntity item)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

            serviceResponse = await _genericBussines.Update(item);

            return serviceResponse;
        }
    }
}