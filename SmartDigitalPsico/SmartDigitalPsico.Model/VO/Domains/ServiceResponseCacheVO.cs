using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts.Interface;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class ServiceResponseCacheVO<T> : ServiceResponse<T>, IDataCacheVO<T>
    {
        public ServiceResponseCacheVO()
        {

        }
        public ServiceResponseCacheVO(IServiceResponse<T> serviceResponse
            , string cacheKey, DateTime dateTimeSlidingExpiration)
        {
            CacheKey = cacheKey;
            CacheId = Guid.NewGuid().ToString();
            DateTimeSlidingExpiration = dateTimeSlidingExpiration;
            Data = serviceResponse.Data;
            Success = serviceResponse.Success;
            Message = serviceResponse.Message;
        }
        public ServiceResponseCacheVO(T dataToCache
           , string cacheKey, DateTime dateTimeSlidingExpiration)
        {
            CacheKey = cacheKey;
            CacheId = Guid.NewGuid().ToString();
            DateTimeSlidingExpiration = dateTimeSlidingExpiration;
            Data = dataToCache;
            Success = true;
            Message = string.Empty;
        }


        public DateTime DateTimeSlidingExpiration { get; set; }
        public string CacheKey { get; set; }
        public string CacheId { get; set; }

    }
}
