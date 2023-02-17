using System.Collections.Generic;

namespace SmartDigitalPsico.Domains.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
