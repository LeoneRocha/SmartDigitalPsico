using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Domains.AddVOs
{
    public class AddApplicationLanguageVO : EntityVOBaseDomainAdd
    {
        [MaxLength(5)]
        public string Language { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string LanguageKey { get; set; }

        [MaxLength(255)]
        public string LanguageValue { get; set; }

        [MaxLength(255)]
        public string ResourceKey { get; set; }

    }
}