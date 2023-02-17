﻿using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Services.Generic
{
    public class GenericServicesEntityBase<Entity, Business, ResutEntity>
        : IGenericBusinessEntityBase<Entity, ResutEntity>
        where Entity : EntityBase
        where Business : IGenericBusinessEntityBase<Entity, ResutEntity>
        where ResutEntity : class

    {
        private readonly IMapper _mapper;
        private readonly Business _genericBusiness;
        public GenericServicesEntityBase(IMapper mapper, Business genericBusiness)
        {
            _mapper = mapper;
            _genericBusiness = genericBusiness;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Create(ResutEntity item)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

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
        public async Task<ServiceResponse<List<ResutEntity>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<ResutEntity>>();

            serviceResponse = await _genericBusiness.FindAll();

            return serviceResponse;
        }
        public async Task<ServiceResponse<ResutEntity>> FindByID(long id)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

            serviceResponse = await _genericBusiness.FindByID(id);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query)
        {
            var serviceResponse = new ServiceResponse<List<ResutEntity>>();

            serviceResponse = await _genericBusiness.FindWithPagedSearch(query);

            return serviceResponse;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            var serviceResponse = new ServiceResponse<int>();

            serviceResponse = await _genericBusiness.GetCount(query);

            return serviceResponse;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Update(ResutEntity item)
        {
            var serviceResponse = new ServiceResponse<ResutEntity>();

            serviceResponse = await _genericBusiness.Update(item);

            return serviceResponse;
        }
    }
}