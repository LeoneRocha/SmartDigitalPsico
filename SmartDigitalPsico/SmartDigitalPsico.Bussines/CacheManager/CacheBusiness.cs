using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Repository.CacheManager;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using System.Reflection;

namespace SmartDigitalPsico.Business.CacheManager
{
    public class CacheBusiness : ICacheBusiness
    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly string _cacheKey = string.Empty;
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        private readonly IDiskCacheRepository _diskCacheRepository;
        private readonly CacheConfigurationVO _cacheConfig;
        private static ETypeLocationCache typeCache;
        private readonly IApplicationCacheLogRepository _applicationCacheLogRepository;

        public CacheBusiness(IMapper mapper, IConfiguration configuration
            , IMemoryCacheRepository memoryCacheRepository
            , IDiskCacheRepository diskCacheRepository
            , IApplicationCacheLogRepository applicationCacheLogRepository
            , IOptions<CacheConfigurationVO> cacheConfig)
        {
            _mapper = mapper;
            _configuration = configuration;
            _memoryCacheRepository = memoryCacheRepository;
            _diskCacheRepository = diskCacheRepository;
            _applicationCacheLogRepository = applicationCacheLogRepository;
            _cacheConfig = cacheConfig.Value;
            typeCache = getTypeCache();
        }

        public bool Remove<T>(string? cacheKey)
        {
            bool result = false;
            cacheKey = getCacheKey<T>(cacheKey);

            switch (typeCache)
            {
                case ETypeLocationCache.Disk:
                    break;
                case ETypeLocationCache.Memory:
                    result = _memoryCacheRepository.Remove(cacheKey);
                    break;
                case ETypeLocationCache.MongoDB:
                    break;
                case ETypeLocationCache.AzureStorage:
                    break;
                case ETypeLocationCache.AzureCosmoDB:
                    break;
                case ETypeLocationCache.AzureRedis:
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        public bool Set<T>(string? cacheKey, T value)
        {
            cacheKey = getCacheKey<T>(cacheKey);
            bool result = false;
            switch (typeCache)
            {
                case ETypeLocationCache.Disk:
                    result = processCacheRepositoryDisk(cacheKey, value); 
                    break;
                case ETypeLocationCache.Memory:
                    result = _memoryCacheRepository.Set(cacheKey, value);
                    break;
                case ETypeLocationCache.MongoDB:
                    break;
                case ETypeLocationCache.AzureStorage:
                    break;
                case ETypeLocationCache.AzureCosmoDB:
                    break;
                case ETypeLocationCache.AzureRedis:
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        } 
        public bool TryGet<T>(string? cacheKey, out T valueResult) where T : new()
        {
            T _valueResult = new();

            bool result = false;
            try
            {
                cacheKey = getCacheKey<T>(cacheKey);
                switch (typeCache)
                {
                    case ETypeLocationCache.Disk:
                        var resultDisk = _diskCacheRepository.TryGetAsync<T>(cacheKey).GetAwaiter().GetResult();
                        result = checkCacheIsValid(resultDisk, cacheKey);
                        _valueResult = checkCacheIsValid(resultDisk, cacheKey) ? resultDisk.Value : _valueResult;
                        break;
                    case ETypeLocationCache.Memory:
                        result = _memoryCacheRepository.TryGet(cacheKey, out _valueResult);
                        break;
                    case ETypeLocationCache.MongoDB:
                        break;
                    case ETypeLocationCache.AzureStorage:
                        break;
                    case ETypeLocationCache.AzureCosmoDB:
                        break;
                    case ETypeLocationCache.AzureRedis:
                        break;
                    default:
                        break;
                }
                valueResult = _valueResult;
            }
            catch (Exception ex)
            {
                valueResult = _valueResult;
                return result;
            }
            return result;
        }

        public bool IsEnable()
        {
            bool isEnable = _cacheConfig.IsEnable;

            return isEnable;
        }

        public DateTime GetSlidingExpiration()
        {
            return DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours).AddMinutes(_cacheConfig.SlidingExpirationInMinutes);
        }

        public static async Task SaveDataToCache<T>(string keyCache, T dataToCache, ICacheBusiness cacheBusiness)
        {
            await Task.FromResult(0);

            ServiceResponseCacheVO<T> cacheSave = new ServiceResponseCacheVO<T>(dataToCache, keyCache, cacheBusiness.GetSlidingExpiration());
            bool resultAction = cacheBusiness.Set<ServiceResponseCacheVO<T>>(keyCache, cacheSave);
        }
        public static async Task<ServiceResponse<T>> GetDataFromCache<T>(ICacheBusiness cacheBusiness, string keyCache)
        {
            await Task.FromResult(0);

            ServiceResponse<T> result = new ServiceResponse<T>();
             
            if (cacheBusiness.IsEnable())
            {
                bool existsCache = cacheBusiness.TryGet<ServiceResponseCacheVO<T>>(keyCache, out ServiceResponseCacheVO<T> cachedResult);
                if (existsCache)
                {
                    result.Data = cachedResult.Data;
                }
            } 
            return result;
        }


        #region PRIVATES
        private bool processCacheRepositoryDisk<T>(string cacheKey, T? value)
        {
            bool result = false;

            result = _diskCacheRepository.SetAsync(cacheKey, value).GetAwaiter().GetResult();

            DateTime dateTimeSlidingExpiration;

            DateTime.TryParse(getPropValue(value, "DateTimeSlidingExpiration").ToString(), out dateTimeSlidingExpiration);
            string _cacheId = getPropValue(value, "CacheId").ToString();
            var addLogCache = new ApplicationCacheLog()
            {
                CacheKey = cacheKey,
                CacheId = _cacheId,
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                LastAccessDate = DateTime.Now,
                DateTimeSlidingExpiration = dateTimeSlidingExpiration,
                Enable = true
            };
            _applicationCacheLogRepository.Create(addLogCache);

            return result;
        }

        private bool checkCacheIsValid<T>(KeyValuePair<bool, T> resultDisk, string cacheKey) where T : new()
        {
            if (resultDisk.Value != null)
            {
                var valorData = getPropValue(resultDisk.Value, "Data");

                if (valorData != null)
                {
                    var valorExpiracao = getPropValue(resultDisk.Value, "DateTimeSlidingExpiration");
                    DateTime dataExpiracao = DateTime.MinValue;

                    bool temData = DateTime.TryParse(valorExpiracao.ToString(), out dataExpiracao);
                    if (temData && dataExpiracao != DateTime.MinValue && DateTime.Now >= dataExpiracao)
                    {
                        bool resultCacheLogDisk = _diskCacheRepository.RemoveAsync(cacheKey).GetAwaiter().GetResult();

                        bool resultCacheLog = _applicationCacheLogRepository.Delete(cacheKey).GetAwaiter().GetResult();

                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        private static object getPropValue(object source, string propertyName)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            return property?.GetValue(source);
        }

        private string getCacheKey<T>(string? cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                cacheKey = $"{typeof(T)}";
            }
            return cacheKey;
        }
        private ETypeLocationCache getTypeCache()
        {
            ETypeLocationCache typeCache = _cacheConfig.TypeCache;

            return typeCache;
        }


        #endregion
    }
}