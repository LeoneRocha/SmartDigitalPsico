using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class AddApplicationConfigSettingVO : EntityVOBaseDomainAdd
    { 
        public string Description { get; set; }
 
        public string Language { get; set; } 

        public string EndPointUrl_StorageFiles { get; set; }
         
        public string EndPointUrl_Cache { get; set; }
    }
}