using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Model.VO.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.CacheManager
{
    public class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheConfigurationVO _cacheConfig;
        private MemoryCacheEntryOptions _cacheOptions;
        //https://learn.microsoft.com/en-us/dotnet/core/extensions/caching
        public MemoryCacheRepository(IMemoryCache memoryCache, IOptions<CacheConfigurationVO> cacheConfig)
        {
            _memoryCache = memoryCache;// host.Services.GetRequiredService<IMemoryCache>();
            _cacheConfig = cacheConfig.Value;
            if (_cacheConfig != null)
            {
                DateTime absoluteExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours);
                absoluteExpiration = DateTime.Now.AddMinutes(_cacheConfig.AbsoluteExpirationInMinutes);

                _cacheOptions = new MemoryCacheEntryOptions
                { 
                    AbsoluteExpiration = absoluteExpiration,
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(_cacheConfig.SlidingExpirationInMinutes)
                };
            }
        }
        public bool TryGet<T>(string cacheKey, out T value)
        {
            bool isSuccessGet = false;
            try
            {
                value = _memoryCache.Get<T>(cacheKey);

                _memoryCache.TryGetValue(cacheKey, out value);
                if (value != null)
                {

                    isSuccessGet = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccessGet;
        }

        public bool Set<T>(string cacheKey, T value)
        {
            bool isSuccessSet = false;
            try
            {
                _memoryCache.Set(cacheKey, value, _cacheOptions);

                isSuccessSet = true;
            }
            catch (Exception ex)
            {

                return isSuccessSet;
            }


            return isSuccessSet;
        }

        public bool Remove(string cacheKey)
        {
            try
            {
                _memoryCache.Remove(cacheKey);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
