using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class UserLoginVO : ISupportsHyperMedia

    {
        [MaxLength(25)]
        [Required] 
        public string Login { get; set; }
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}