using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains
{
    [Table("Officies", Schema = "dbo")]
    public class Office : EntityBaseSimple, IEntityBaseDomains
    {
        [Column("Description", TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Column("Language", TypeName = "char(5)")]
        [MaxLength(5)]
        public string Language { get; set; }
    }
}