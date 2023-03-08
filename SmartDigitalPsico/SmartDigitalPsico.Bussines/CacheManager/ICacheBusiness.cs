using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
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
        void CalculateSlidingExpiration(ServiceResponseCache<List<GetGenderVO>> cacheSave);
    }
}
