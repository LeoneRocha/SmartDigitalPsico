using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{

    public interface IEntityDataCache<T>
    {
        public DateTime DateTimeSlidingExpiration { get; set; }

        public T Data { get; set; }
    }
}