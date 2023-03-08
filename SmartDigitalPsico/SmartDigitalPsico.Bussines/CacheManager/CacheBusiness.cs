using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Repository.CacheManager;
using SmartDigitalPsico.Repository.Contract.Principals;
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
        private readonly CacheConfiguration _cacheConfig;

        private readonly static ETypeLocationCache typeCache = ETypeLocationCache.Disk;

        public CacheBusiness(IMapper mapper, IConfiguration configuration
            , IMemoryCacheRepository memoryCacheRepository
            , IDiskCacheRepository diskCacheRepository, IOptions<CacheConfiguration> cacheConfig)
        {
            _mapper = mapper;
            _configuration = configuration;
            _memoryCacheRepository = memoryCacheRepository;
            _diskCacheRepository = diskCacheRepository;
            _cacheConfig = cacheConfig.Value;
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
                    result = _diskCacheRepository.SetAsync(cacheKey, value).GetAwaiter().GetResult();
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
                        result = checkCacheIsValid(resultDisk);
                        _valueResult = checkCacheIsValid(resultDisk) ? resultDisk.Value : _valueResult;
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



        #region PRIVATES
        private bool checkCacheIsValid<T>(KeyValuePair<bool, T> resultDisk) where T : new()
        {
            if (resultDisk.Value != null)
            {
                var valorData = getPropValue(resultDisk.Value, "Data");

                if (valorData != null)
                {
                    var valorExpiracao = getPropValue(resultDisk.Value, "DateTimeSlidingExpiration");
                    DateTime dataExpiracao = DateTime.MinValue;

                    bool temData = DateTime.TryParse(valorExpiracao.ToString(), out dataExpiracao);
                    if (temData &&  DateTime.Now >= dataExpiracao)
                    {
                        return false;
                    }
                    return true;
                } 
            }
            return false;
        }

        public static object getPropValue(object source, string propertyName)
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

        public void CalculateSlidingExpiration(ServiceResponseCache<List<GetGenderVO>> cacheSave)
        {
            cacheSave.DateTimeSlidingExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours).AddMinutes(_cacheConfig.SlidingExpirationInMinutes);
        }


        #endregion



    }
}