using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO
{
    public abstract class EntityVOBase : ISupportsHyperMedia
    {
        public long Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }

        //public string Email { get; set; }

        public bool Enable { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}