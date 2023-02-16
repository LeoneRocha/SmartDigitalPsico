﻿using AutoMapper;
using SmartDigitalPsico.Bussines.Generic.Contracts;
using SmartDigitalPsico.Data.Repository.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Bussines.Generic
{
    public class GenericBussinesEntityBase<Entity, Repo, ResutEntity>
        : IGenericBussinesEntityBase<Entity, ResutEntity>
        where Entity : EntityBase
        where Repo : IRepositoryEntityBase<Entity>
        where ResutEntity : EntityDTOBase

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        public GenericBussinesEntityBase(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Create(ResutEntity item)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();

            Entity entityAdd = _mapper.Map<Entity>(item);

            Entity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register Created.";
            return response;
        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            bool exists = await _genericRepository.Exists(id);
            if (!exists)
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            }
            else
            {
                response.Success = await _genericRepository.Delete(id); 
                if (response.Success)
                {
                    response.Message = "Register deleted.";
                    response.Success = true;
                }
            } 

            return response;
        }
        public async Task<ServiceResponse<bool>> Exists(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            bool entityResponse = await _genericRepository.Exists(id);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindAll()
        {
            ServiceResponse<List<ResutEntity>> response = new ServiceResponse<List<ResutEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<ResutEntity>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<ResutEntity>> FindByID(long id)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();
            Entity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<ResutEntity>> response = new ServiceResponse<List<ResutEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<ResutEntity>(c)).ToList();
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            int entityResponse = await _genericRepository.GetCount(query);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Registers Counted.";
            return response;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Update(ResutEntity item)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();

            var entityUpdate = _mapper.Map<Entity>(item);
            Entity entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register Updated.";
            return response;
        }
    }
}