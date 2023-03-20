using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Contracts
{
    public abstract class EntityVOBaseDomainAdd : IEntityVOAdd
    {
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(5)]
        public string Language { get; set; }
    }
}