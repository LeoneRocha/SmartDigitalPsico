using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class GetUserVO : UpdateUserVO, ISupportsHyperMedia
    {   

        [MaxLength(100)]
        public string Email { get; set; }

        public List<GetRoleGroupVO> RoleGroups { get; set; }
         
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}