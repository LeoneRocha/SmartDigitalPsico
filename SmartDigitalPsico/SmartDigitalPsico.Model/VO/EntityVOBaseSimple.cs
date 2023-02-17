using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Model.Contracts
{
    public class EntityVOBaseSimple : ISupportsHyperMedia
    { 
        public long Id { get; set; }

        public string Description { get; set; }

        public string Language { get; set; } 
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}