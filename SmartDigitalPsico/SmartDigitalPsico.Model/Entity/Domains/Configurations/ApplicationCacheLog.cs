using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Domains.Configurations
{
    [Table("ApplicationCacheLogs", Schema = "dbo")]
    public class ApplicationCacheLog : EntityBaseSimple 
    { 
         
        public DateTime DateTimeSlidingExpiration { get; set; }

        [Column("CacheId", TypeName = "varchar(255)")]
        [MaxLength(255)] 
        public string CacheId { get; set; }


        [Column("CacheKey", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string CacheKey { get; set; }

    }
}