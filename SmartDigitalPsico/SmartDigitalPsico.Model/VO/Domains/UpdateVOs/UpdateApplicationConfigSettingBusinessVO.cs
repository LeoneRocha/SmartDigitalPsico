using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class UpdateApplicationConfigSettingBusinessVO : EntityVOBaseDomain
    {
        public string Description { get; set; }

        public string Language { get; set; }

        public string EndPointUrl_StorageFiles { get; set; }

        public string EndPointUrl_Cache { get; set; }
    }
}