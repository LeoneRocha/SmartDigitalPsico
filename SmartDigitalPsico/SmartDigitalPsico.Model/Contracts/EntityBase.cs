using SmartDigitalPsico.Model.Entity.Principals;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBase : EntityBaseSimple  
    {
        [Column("Name", TypeName = "varchar(200)", Order = 2)]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(200)", Order = 3)]
        public string Email { get; set; } 
    }
}