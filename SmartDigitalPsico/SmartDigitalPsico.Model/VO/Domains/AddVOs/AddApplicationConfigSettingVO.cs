using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Domains.AddVOs
{
    public class AddApplicationConfigSettingVO : EntityVOBaseDomainAdd
    {
        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(5)]
        public string Language { get; set; }

        [MaxLength(255)]
        public string EndPointUrl_StorageFiles { get; set; }

        [MaxLength(255)]
        public string EndPointUrl_Cache { get; set; }
    }
}