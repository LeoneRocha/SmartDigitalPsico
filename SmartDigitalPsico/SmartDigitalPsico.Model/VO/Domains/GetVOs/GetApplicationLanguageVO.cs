using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains.GetVOs
{
    public class GetApplicationLanguageVO : EntityVOBaseDomain, ISupportsHyperMedia
    {
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

        public string Language { get; set; }


        public string Description { get; set; }


        public string LanguageKey { get; set; }


        public string LanguageValue { get; set; }
         
        public string ResourceKey { get; set; }

    }
}