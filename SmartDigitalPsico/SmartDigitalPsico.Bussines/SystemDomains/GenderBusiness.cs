using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness
      : GenericBusinessEntityBaseSimple<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderRepository>, IGenderBusiness
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _entityRepository;
        private readonly ICacheBusiness _cacheBusiness;
        AuthConfigurationVO _configurationAuth;
        private readonly IStringLocalizer<SharedResource> _localizer;
        public GenderBusiness(IMapper mapper, IGenderRepository entityRepository, ICacheBusiness cacheBusiness,
            IOptions<AuthConfigurationVO> configurationAuth,
            IValidator<Gender> entityValidator
            , IApplicationLanguageRepository applicationLanguageRepository
            , ICacheBusiness cacheBusines)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
        {
            _mapper = mapper;
            _entityRepository = entityRepository;
            _cacheBusiness = cacheBusiness;
            _configurationAuth = configurationAuth.Value; 
        }

        public override async Task<ServiceResponse<List<GetGenderVO>>> FindAll()
        {
            string keyCache = "FindAll_GetGenderVO";

            ServiceResponse<List<GetGenderVO>> result = new ServiceResponse<List<GetGenderVO>>();
            List<GetGenderVO> listEntity = new List<GetGenderVO>();

            long idu = this.UserId;

            if (_cacheBusiness.IsEnable())
            {
                bool existsCache = _cacheBusiness.TryGet<ServiceResponseCacheVO<List<GetGenderVO>>>(keyCache, out ServiceResponseCacheVO<List<GetGenderVO>> cachedResult);
                if (!existsCache)
                {
                    result = await base.FindAll();
                    ServiceResponseCacheVO<List<GetGenderVO>> cacheSave = new ServiceResponseCacheVO<List<GetGenderVO>>(result, keyCache, _cacheBusiness.GetSlidingExpiration());

                    bool resultAction = _cacheBusiness.Set<ServiceResponseCacheVO<List<GetGenderVO>>>(keyCache, cacheSave);
                }
                else
                {
                    result.Data = cachedResult.Data;
                }
            }
            else
            {
                result = await base.FindAll();
            }

            return result;
        }
        public override async Task<ServiceResponse<GetGenderVO>> FindByID(long id)
        {
            ServiceResponse<GetGenderVO> response = new ServiceResponse<GetGenderVO>();
            try
            {
                Gender entityResponse = await _entityRepository.FindByID(id);

                if (entityResponse != null)
                {
                    response.Data = _mapper.Map<GetGenderVO>(entityResponse);
                    response.Success = true;
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                        ("RegisterIsFound", base._applicationLanguageRepository,base._cacheBusiness);  
                }
                else
                {
                    response.Success = false;
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);

                    //response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>("RegisterIsNotFound", _localizer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
         
        public override async Task<ServiceResponse<GetGenderVO>> Update(UpdateGenderVO item)
        {
            ServiceResponse<GetGenderVO> response = new ServiceResponse<GetGenderVO>();

            bool entityExists = await _entityRepository.Exists(item.Id);

            if (!entityExists)
            {
                response.Success = false;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);
                return response;
            }   
            Gender entityUpdate = await _entityRepository.FindByID(item.Id);
            entityUpdate.Description = item.Description;
            entityUpdate.Enable = item.Enable;
            entityUpdate.Language = item.Language;            

            response = await Validate(entityUpdate);
            entityUpdate.ModifyDate = DateTime.Now;
            if (response.Success)
            {
                Gender entityResponse = await _entityRepository.Update(entityUpdate);

                response.Data = _mapper.Map<GetGenderVO>(entityResponse);
                response.Success = true;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                           ("RegisterUpdated", base._applicationLanguageRepository, base._cacheBusiness);
            } 
            return response;

        }
    }
}