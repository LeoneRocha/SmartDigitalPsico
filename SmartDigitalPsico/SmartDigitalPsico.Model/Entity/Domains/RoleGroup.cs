using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Principals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains
{
    [Table("RoleGroups", Schema = "dbo")]
    public class RoleGroup : EntityBaseSimple, IEntityBaseDomains
    {
        public List<User> Users { get; set; }

        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column("Language", TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string Language { get; set; }

        [Column("RolePolicyClaimCode", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string RolePolicyClaimCode { get; set; }
    }
}