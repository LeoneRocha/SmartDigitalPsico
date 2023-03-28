using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Contracts
{
    public abstract class EntityVOBaseName : EntityVOBase
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }


        [MaxLength(200)]
        [Required]
        public string Email { get; set; }

    }
}