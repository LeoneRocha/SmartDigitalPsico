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
        public string Description { get; set; }

        [Column("Language", TypeName = "char(5)")]
        [MaxLength(5)]
        public string Language { get; set; }

    }
}