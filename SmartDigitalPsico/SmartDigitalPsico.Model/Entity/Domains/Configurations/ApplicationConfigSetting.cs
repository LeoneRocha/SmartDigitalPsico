using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{
    [Table("ApplicationConfigSetting", Schema = "dbo")]
    public class ApplicationConfigSetting : EntityBaseSimple, IEntityBaseDomains
    {
        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column("Language", TypeName = "char(5)")]
        [MaxLength(5)]
        public string Language { get; set; }

        [Column("EndPointUrl_StorageFiles", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string EndPointUrl_StorageFiles { get; set; }

        [Column("EndPointUrl_Cache", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string EndPointUrl_Cache { get; set; }

        [Column("TypeLocationSaveFiles")]
        public ETypeLocationSaveFiles TypeLocationSaveFiles { get; set; }

        [Column("TypeLocationCache")]
        public ETypeLocationCache TypeLocationCache { get; set; }

        [Column("TypeLocationQueeMessaging")]
        public ETypeLocationQueeMessaging TypeLocationQueeMessaging { get; set; }
    }
}