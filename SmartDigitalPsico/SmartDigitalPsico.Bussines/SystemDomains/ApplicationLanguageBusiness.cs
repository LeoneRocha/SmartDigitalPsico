using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using System.Globalization;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class ApplicationLanguageBusiness
      : GenericBusinessEntityBaseSimple<ApplicationLanguage, AddApplicationLanguageVO, UpdateApplicationLanguageVO, GetApplicationLanguageVO, IApplicationLanguageRepository>, IApplicationLanguageBusiness
    {
        private readonly IMapper _mapper;
        private readonly IApplicationLanguageRepository _genericRepository;
        private readonly ICacheBusiness _cacheBusiness;

        public ApplicationLanguageBusiness(IMapper mapper, IApplicationLanguageRepository entityRepository
             , IValidator<ApplicationLanguage> entityValidator, IApplicationLanguageRepository applicationLanguageRepository,
               ICacheBusiness cacheBusiness)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository)
        {
            _mapper = mapper;
            _genericRepository = entityRepository;
            _cacheBusiness = cacheBusiness;
        }
        public static async Task<string> GetLocalization<T>(string key, Microsoft.Extensions.Localization.IStringLocalizer<T> localizer)
        {
            string result = "NotFoundLocalization";
            try
            {
                var culturenameCurrent = CultureInfo.CurrentCulture;

                var findKey = CultureDateTimeHelper.GetNameAndCulture(key);
                string message = localizer.GetString(findKey);

                result = message;
            }
            catch (Exception)
            {

            }
            await Task.FromResult(string.Empty);

            return result;
        }
        public override async Task<ServiceResponse<List<GetApplicationLanguageVO>>> FindAll()
        {
            string keyCache = "FindAll_GetApplicationLanguageVO";

            ServiceResponse<List<GetApplicationLanguageVO>> result = new ServiceResponse<List<GetApplicationLanguageVO>>();
            List<GetApplicationLanguageVO> listEntity = new List<GetApplicationLanguageVO>();

            long idu = this.UserId;

            if (_cacheBusiness.IsEnable())
            {
                bool existsCache = _cacheBusiness.TryGet<ServiceResponseCacheVO<List<GetApplicationLanguageVO>>>(keyCache, out ServiceResponseCacheVO<List<GetApplicationLanguageVO>> cachedResult);
                if (!existsCache)
                {
                    result = await base.FindAll();
                    ServiceResponseCacheVO<List<GetApplicationLanguageVO>> cacheSave = new ServiceResponseCacheVO<List<GetApplicationLanguageVO>>(result, keyCache, _cacheBusiness.GetSlidingExpiration());

                    bool resultAction = _cacheBusiness.Set<ServiceResponseCacheVO<List<GetApplicationLanguageVO>>>(keyCache, cacheSave);
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
         

        public static async Task<string> GetLocalization<T>(string key, IApplicationLanguageRepository languageRepository)
        { 
            string result = $"NotFoundLocalization|{key}|";
            try
            { 
                var culturenameCurrent = CultureInfo.CurrentCulture;
                var findKey = CultureDateTimeHelper.GetNameAndCulture(key);

                var languageFind = await languageRepository.Find(culturenameCurrent.Name, key);
                 
                string message = languageFind.LanguageValue;

                result = message;
            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}