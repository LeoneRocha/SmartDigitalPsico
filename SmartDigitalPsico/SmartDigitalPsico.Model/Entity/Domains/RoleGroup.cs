using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains
{
    [Table("RoleGroups", Schema = "dbo")]
    public class RoleGroup : EntityBaseSimple
    { 
        public List<User> Users { get; set; }
    }
}