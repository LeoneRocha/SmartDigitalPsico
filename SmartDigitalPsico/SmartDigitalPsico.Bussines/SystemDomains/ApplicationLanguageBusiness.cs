using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
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

        public ApplicationLanguageBusiness(IMapper mapper, IApplicationLanguageRepository entityRepository
             , IValidator<ApplicationLanguage> entityValidator, IApplicationLanguageRepository applicationLanguageRepository,
               ICacheBusiness cacheBusiness)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
        {
            _mapper = mapper;
            _genericRepository = entityRepository;
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
            long idu = this.UserId;

            string keyCache = "FindAll_GetApplicationLanguageVO";

            ServiceResponse<List<GetApplicationLanguageVO>> result = new ServiceResponse<List<GetApplicationLanguageVO>>();
            List<GetApplicationLanguageVO> listEntity = new List<GetApplicationLanguageVO>();

            result = await CacheBusiness.GetDataFromCache<List<GetApplicationLanguageVO>>(base._cacheBusiness, keyCache);

            if (result.Data == null && base._cacheBusiness.IsEnable())
            {
                result = await base.FindAll();

                await CacheBusiness.SaveDataToCache(keyCache, result.Data, base._cacheBusiness);
            }
            else
            {
                result = await base.FindAll();
            }

            return result;
        }

        public static async Task<string> GetLocalization<T>(string key,
            IApplicationLanguageRepository languageRepository, ICacheBusiness cacheBusiness)
        {
            string resultLocalization = $"NotFoundLocalization|{key}|";
            try
            {
                var culturenameCurrent = CultureInfo.CurrentCulture;
                var findKey = CultureDateTimeHelper.GetNameAndCulture(key);

                string keyCache = "FindAll_GetApplicationLanguageVO";
                ServiceResponse<List<GetApplicationLanguageVO>> resultFromCache = new ServiceResponse<List<GetApplicationLanguageVO>>();

                resultFromCache = await CacheBusiness.GetDataFromCache<List<GetApplicationLanguageVO>>(cacheBusiness, keyCache);

                string resourceKey = "SharedResource";
                string language = culturenameCurrent.Name;
                if (resultFromCache != null && resultFromCache.Data != null && resultFromCache.Data.Count > 0)
                {
                    try
                    {
                        GetApplicationLanguageVO languageFindFromCache = filterAndGetSingle(resultFromCache, resourceKey, key, language);
                        resultLocalization = languageFindFromCache.LanguageValue;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    var languageFindDB = await languageRepository.Find(language, key, resourceKey);
                    resultLocalization = languageFindDB.LanguageValue;
                }
            }
            catch (Exception)
            {

            }
            return resultLocalization;
        }

        private static GetApplicationLanguageVO filterAndGetSingle(ServiceResponse<List<GetApplicationLanguageVO>> resultFromCache, string resourceKey, string key, string language)
        {
            return resultFromCache.Data.Single(p => p.ResourceKey.ToUpper().Trim().Equals(resourceKey.ToUpper().Trim())
            && p.LanguageKey.ToUpper().Trim().Equals(key.ToUpper().Trim())
            && p.Language.ToUpper().Trim().Equals(language.ToUpper().Trim()));
        }
    }
}