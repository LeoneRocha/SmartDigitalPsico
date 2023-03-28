using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.CacheManager
{
    public interface IDiskCacheRepository : ICacheRepository
    {
        public Task<KeyValuePair<bool, T>> TryGetAsync<T>(string cacheKey) where T : new();

        public Task<bool> RemoveAsync(string cacheKey);

        public Task<bool> SetAsync<T>(string cacheKey, T value);
    }

}
