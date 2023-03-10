using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class GetGenderVO : ISupportsHyperMedia, IEntityVO
    {
        public long Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(5)]
        public string Language { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();


    }
}