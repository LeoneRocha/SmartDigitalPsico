using SmartDigitalPsico.Model.Entity.Domains;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class UpdateUserVO : EntityVOBaseName
    {  
        public List<long> RoleGroupsIds { get; set; }
         
        [MaxLength(50)] 
        public string? Role { get; set; }
         
    }
}