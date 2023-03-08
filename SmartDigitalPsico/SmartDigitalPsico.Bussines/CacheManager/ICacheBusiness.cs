using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Business.CacheManager
{
    public interface ICacheBusiness
    {
        bool TryGet<T>(string? cacheKey, out T value) where T : new();
        bool Set<T>(string? cacheKey, T value);
        bool Remove<T>(string? cacheKey);
    }

}
