using SmartDigitalPsico.Domains.Hypermedia.Utils;

namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{
    public class CacheData
    {
        public string CacheKey { get; set; }

         
    }

    public class ServiceResponseCache<T> : ServiceResponse<T>, IEntityDataCache<T>
    {
        public DateTime DateTimeSlidingExpiration { get  ; set  ; }
    }
}
