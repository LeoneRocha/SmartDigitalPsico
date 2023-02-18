using SmartDigitalPsico.Model.Entity.Domains;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class UpdateUserVO : EntityVOBase
    { 
        [MaxLength(200)]
        [Required]
        public string Email { get; set; }
         
        public List<long> RoleGroupsIds { get; set; }
         
        [MaxLength(50)] 
        public string? Role { get; set; }
    }
}