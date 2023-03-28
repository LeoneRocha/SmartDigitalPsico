using SmartDigitalPsico.Domains.Hypermedia.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts.Interface
{

    public interface IDataCacheVO<T>
    {
        public string CacheKey { get; set; }
        public string CacheId { get; set; }
        public DateTime DateTimeSlidingExpiration { get; set; }

        public T Data { get; set; }
    }
}