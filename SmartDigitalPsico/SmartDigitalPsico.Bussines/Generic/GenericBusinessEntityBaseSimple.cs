using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Business.Validation.Helper;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
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
        private readonly IStringLocalizer<SharedResource> _localizer;
        protected readonly IApplicationLanguageRepository _applicationLanguageRepository;
        protected readonly ICacheBusiness _cacheBusiness;

        public GenericBusinessEntityBaseSimple(IMapper mapper, Repo UserRepository,
            IValidator<TEntity> entityValidator
            , IApplicationLanguageRepository applicationLanguageRepository
            , ICacheBusiness cacheBusiness
          )
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
            _entityValidator = entityValidator;
            _applicationLanguageRepository = applicationLanguageRepository;
            _cacheBusiness = cacheBusiness;
            // _localizer = localizer;
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

                response = await Validate(entityAdd);
                if (response.Success)
                {
                    TEntity entityResponse = await _genericRepository.Create(entityAdd);
                    response.Data = _mapper.Map<TEntityResult>(entityResponse);
                    response.Message = await getMessageFromLocalization("RegisterCreated");
                }
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
                bool entityExists = await _genericRepository.Exists(id);

                if (!entityExists)
                {
                    response.Success = false;
                    response.Message = await getMessageFromLocalization("RegisterIsNotFound");
                    response.Errors.Add(new ErrorResponse()
                    {
                        Message = response.Message,
                        Name = "Delete"
                    });
                    return response;
                }

                bool entityResponse = await _genericRepository.Delete(id);

                response.Data = entityResponse;
                response.Success = true;
                response.Message = await getMessageFromLocalization("RegisterDeleted");
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
                    response.Message = await getMessageFromLocalization("RegisterIsNotFound");
                    return response;
                }
                var entityUpdate = _mapper.Map<TEntity>(item);
                response = await Validate(entityUpdate);
                entityUpdate.ModifyDate = DateTime.Now;

                if (response.Success)
                {
                    TEntity entityResponse = await _genericRepository.Update(entityUpdate);
                    response.Data = _mapper.Map<TEntityResult>(entityResponse);
                    response.Message = await getMessageFromLocalization("RegisterUpdated");
                }
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
                response.Message = await getMessageFromLocalization("RegisterExist");
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
                response.Message = await getMessageFromLocalization("RegisterExist");
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
                    response.Message = await getMessageFromLocalization("RegisterIsFound");
                }
                else
                {
                    response.Success = false;
                    response.Message = await getMessageFromLocalization("RegisterIsNotFound");
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
                response.Message = await getMessageFromLocalization("RegisterIsFound");
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
                response.Message = await getMessageFromLocalization("RegisterCounted");
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
                    response.Message = await getMessageFromLocalization("RegisterIsNotFound");
                    return response;
                }
                else
                {
                    response.Success = await _genericRepository.EnableOrDisable(id);
                    if (response.Success)
                    {
                        response.Message = await getMessageFromLocalization("RegisterUpdated");
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
        private async Task<string> getMessageFromLocalization(string key)
        {
            try
            {
                return await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                                   (key, this._applicationLanguageRepository, _cacheBusiness);
            }
            catch (Exception)
            {

            }
            return "Erro get Message";
        }
    }
}