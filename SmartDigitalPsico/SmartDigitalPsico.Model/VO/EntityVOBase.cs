using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityVOBase : ISupportsHyperMedia
    {
        public long Id { get; set; }
         
        public string Name { get; set; }
         
        //public string Email { get; set; }

        public bool Enable { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}