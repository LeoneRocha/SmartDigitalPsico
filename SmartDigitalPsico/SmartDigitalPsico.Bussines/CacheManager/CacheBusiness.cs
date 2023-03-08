using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Repository.CacheManager;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.CacheManager
{
    public class CacheBusiness : ICacheBusiness
    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        //IMemoryCacheRepository _cacheRepository;

        private readonly static ETypeLocationCache typeCache = ETypeLocationCache.Memory;
        private readonly string _cacheKey = string.Empty;
        //private readonly string cacheKey = $"{typeof(T)}";
        private readonly IMemoryCacheRepository _memoryCacheRepository;

        public CacheBusiness(IMapper mapper, IConfiguration configuration, IMemoryCacheRepository memoryCacheRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _memoryCacheRepository = memoryCacheRepository;
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
                        break;
                    case ETypeLocationCache.Memory:
                        result= _memoryCacheRepository.TryGet(cacheKey, out _valueResult);
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

        private string getCacheKey<T>(string? cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                cacheKey = $"{typeof(T)}";
            }
            return cacheKey;
        }
    }
}