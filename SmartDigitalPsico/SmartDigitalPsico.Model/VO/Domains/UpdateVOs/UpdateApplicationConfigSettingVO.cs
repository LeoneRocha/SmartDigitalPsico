using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains.UpdateVOs
{
    public class UpdateApplicationConfigSettingVO : EntityVOBaseDomain
    {
        public string Description { get; set; }

        public string Language { get; set; }

        public string EndPointUrl_StorageFiles { get; set; }

        public string EndPointUrl_Cache { get; set; }
    }
}