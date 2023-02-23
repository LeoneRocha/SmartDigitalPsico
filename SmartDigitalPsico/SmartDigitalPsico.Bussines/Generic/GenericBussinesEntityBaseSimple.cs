﻿using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Generic
{
    public class GenericBusinessEntityBaseSimple<TEntity, TAddEntity, TUpdateEntity, ResultEntity, Repo>
        : IGenericBusinessEntityBaseSimple<TEntity, TAddEntity, TUpdateEntity, ResultEntity>
        where TEntity : EntityBaseSimple
        where TAddEntity : class
        where TUpdateEntity : IEntityVO
        where ResultEntity : class
        where Repo : IRepositoryEntityBaseSimple<TEntity>

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        public GenericBusinessEntityBaseSimple(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<ResultEntity>> Create(TAddEntity item)
        {
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();

            TEntity entityAdd = _mapper.Map<TEntity>(item);

            TEntity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<ResultEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register Created.";
            return response;
        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            bool entityResponse = await _genericRepository.Delete(id);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Register Deleted.";
            return response;
        }
        public virtual async Task<ServiceResponse<ResultEntity>> Update(TUpdateEntity item)
        { 
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();
            TEntity entityFounded = await _genericRepository.FindByID(item.Id); 
            if (entityFounded == null) 
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            } 
            var entityUpdate = _mapper.Map<TEntity>(item);
             
            entityUpdate.ModifyDate = DateTime.Now;

            TEntity entityResponse = await _genericRepository.Update(entityUpdate);
            response.Success = true;
            response.Data = _mapper.Map<ResultEntity>(entityResponse);

            if (response.Success)
                response.Message = "Register Updated.";

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
        public async Task<ServiceResponse<List<ResultEntity>>> FindAll()
        {
            ServiceResponse<List<ResultEntity>> response = new ServiceResponse<List<ResultEntity>>();
            List<TEntity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<ResultEntity>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<ResultEntity>> FindByID(long id)
        {
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();
            TEntity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<ResultEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<ResultEntity>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<ResultEntity>> response = new ServiceResponse<List<ResultEntity>>();
            List<TEntity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<ResultEntity>(c)).ToList();
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
        public virtual async Task<ServiceResponse<bool>> EnableOrDisable(long id)
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
                response.Success = await _genericRepository.EnableOrDisable(id);
                if (response.Success)
                {
                    response.Message = "Register updated.";
                    response.Success = true;
                }
            }

            return response;
        }
    }
}