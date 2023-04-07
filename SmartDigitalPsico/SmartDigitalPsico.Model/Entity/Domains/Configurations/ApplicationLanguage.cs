using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{
    [Table("ApplicationLanguage", Schema = "dbo")]
    public class ApplicationLanguage : EntityBaseSimple, IEntityBaseDomains
    {
        [Column("Language", TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string Language { get; set; }

        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column("LanguageKey", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string LanguageKey { get; set; }

        [Column("ResourceKey ", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string ResourceKey { get; set; }

        [Column("LanguageValue", TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string LanguageValue { get; set; }
    }
}