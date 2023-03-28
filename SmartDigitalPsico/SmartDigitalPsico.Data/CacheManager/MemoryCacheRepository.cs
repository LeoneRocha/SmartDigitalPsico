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
                _cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(_cacheConfig.AbsoluteExpirationInHours),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(_cacheConfig.SlidingExpirationInMinutes)
                };
            }
        }
        public bool TryGet<T>(string cacheKey, out T value)
        {
            _memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) 
                return false;                            
            else                 
                return true;
        }

        public bool Set<T>(string cacheKey, T value)
        {
            try
            {
                _memoryCache.Set(cacheKey, value, _cacheOptions);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
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
