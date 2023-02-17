using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.Collections.Generic;

namespace SmartDigitalPsico.Domains.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
