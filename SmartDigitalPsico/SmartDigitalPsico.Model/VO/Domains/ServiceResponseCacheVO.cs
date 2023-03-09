using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts.Interface;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class ServiceResponseCacheVO<T> : ServiceResponse<T>, IDataCacheVO<T>
    {
        public ServiceResponseCacheVO()
        {

        }
        public ServiceResponseCacheVO(IServiceResponse<T> serviceResponse, DateTime dateTimeSlidingExpiration)
        {
            CacheKey = Guid.NewGuid().ToString();
            DateTimeSlidingExpiration = dateTimeSlidingExpiration;
            Data = serviceResponse.Data;
            Success = serviceResponse.Success;
            Message = serviceResponse.Message;
        }
        public DateTime DateTimeSlidingExpiration { get; set; }
        public string CacheKey { get; set; }
    }
}
