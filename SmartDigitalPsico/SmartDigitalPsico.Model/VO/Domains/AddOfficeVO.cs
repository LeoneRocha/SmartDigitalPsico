using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Domains
{
    public class AddOfficeVO
    {
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(5)]
        public string Language { get; set; }
    }
}