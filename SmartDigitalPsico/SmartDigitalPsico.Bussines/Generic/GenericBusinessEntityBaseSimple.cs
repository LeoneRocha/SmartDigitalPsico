﻿using AutoMapper;
using FluentValidation;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Business.Validation.Helper;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Generic
{
    public class GenericBusinessEntityBaseSimple<TEntity, TEntityAdd, TEntityUpdate, TEntityResult, Repo>
        : IGenericBusinessEntityBaseSimple<TEntity, TEntityAdd, TEntityUpdate, TEntityResult>
        where TEntity : EntityBaseSimple
        where TEntityAdd : IEntityVOAdd
        where TEntityUpdate : IEntityVO
        where TEntityResult : class
        where Repo : IRepositoryEntityBaseSimple<TEntity>

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        private readonly IValidator<TEntity> _entityValidator;
        protected long UserId { get; private set; }

        public GenericBusinessEntityBaseSimple(IMapper mapper, Repo UserRepository, IValidator<TEntity> entityValidator)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
            _entityValidator = entityValidator;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Create(TEntityAdd item)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();
            try
            {
                TEntity entityAdd = _mapper.Map<TEntity>(item);

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;

                TEntity entityResponse = await _genericRepository.Create(entityAdd);

                response.Data = _mapper.Map<TEntityResult>(entityResponse);
                response.Success = true;
                response.Message = "Register Created.";
            }
            catch (Exception)
            { 
                throw;
            }

            return response;
        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            try
            {
                bool entityResponse = await _genericRepository.Delete(id);

                response.Data = entityResponse;
                response.Success = true;
                response.Message = "Register Deleted.";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Update(TEntityUpdate item)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();
            try
            {
                bool entityExists = await _genericRepository.Exists(item.Id);

                if (!entityExists)
                {
                    response.Success = false;
                    response.Message = "Register not found.";
                    return response;
                }

                var entityUpdate = _mapper.Map<TEntity>(item);

                entityUpdate.ModifyDate = DateTime.Now;

                TEntity entityResponse = await _genericRepository.Update(entityUpdate);

                response.Data = _mapper.Map<TEntityResult>(entityResponse);
                response.Success = true;
                response.Message = "Register Updated.";
            }
            catch (Exception ex)
            { 
                throw ex;
            } 
            return response;
        }

        public virtual async Task<ServiceResponse<bool>> Exists(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                bool entityResponse = await _genericRepository.Exists(id);

                response.Data = entityResponse;
                response.Success = true;
                response.Message = "Register exist.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public virtual async Task<ServiceResponse<List<TEntityResult>>> FindAll()
        {
            ServiceResponse<List<TEntityResult>> response = new ServiceResponse<List<TEntityResult>>();
            try
            {
                List<TEntity> entityResponse = await _genericRepository.FindAll();

                response.Data = entityResponse.Select(c => _mapper.Map<TEntityResult>(c)).ToList();

                response.Success = true;
                response.Message = "Register exist.";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> FindByID(long id)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();
            try
            {
                TEntity entityResponse = await _genericRepository.FindByID(id);

                if (entityResponse != null)
                {
                    response.Data = _mapper.Map<TEntityResult>(entityResponse);
                    response.Success = true;
                    response.Message = "Register find.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Register not found.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
        public virtual async Task<ServiceResponse<List<TEntityResult>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<TEntityResult>> response = new ServiceResponse<List<TEntityResult>>();
            try
            {
                List<TEntity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

                response.Data = entityResponse.Select(c => _mapper.Map<TEntityResult>(c)).ToList();
                response.Success = true;
                response.Message = "Register find.";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
        public virtual async Task<ServiceResponse<int>> GetCount(string query)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                int entityResponse = await _genericRepository.GetCount(query);

                response.Data = entityResponse;
                response.Success = true;
                response.Message = "Registers Counted.";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public virtual async Task<ServiceResponse<bool>> EnableOrDisable(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public void SetUserId(long id)
        {
            this.UserId = id;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Validate(TEntity item)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();
            try
            {
                var validationResult = await _entityValidator.ValidateAsync(item);

                response.Success = validationResult.IsValid;
                response.Errors = HelperValidation.GetErrosMap(validationResult);
                response.Message = HelperValidation.GetMessage(validationResult, validationResult.IsValid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}