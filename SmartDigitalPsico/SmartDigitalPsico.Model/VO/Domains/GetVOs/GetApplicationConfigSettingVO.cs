using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains.GetVOs
{
    public class GetApplicationConfigSettingVO : EntityVOBaseDomain, ISupportsHyperMedia
    {
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

        public string Description { get; set; }

        public string Language { get; set; }

        public string EndPointUrl_StorageFiles { get; set; }

        public string EndPointUrl_Cache { get; set; }

    }
}