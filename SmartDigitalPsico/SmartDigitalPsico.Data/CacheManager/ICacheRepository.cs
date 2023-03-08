using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.CacheManager
{
    public interface ICacheRepository
    {
        bool TryGet<T>(string cacheKey, out T value);
        bool Set<T>(string cacheKey, T value);
        bool Remove(string cacheKey);
    }

}
