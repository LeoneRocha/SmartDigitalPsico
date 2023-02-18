using SmartDigitalPsico.Model.Entity.Principals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBase : EntityBaseSimple
    {
        [Column("Name", TypeName = "varchar(255)", Order = 2)] 
        [MaxLength(255)]
        [Required] 
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(100)", Order = 3)]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
    }
}