using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Users", Schema = "dbo")]
    public class User : EntityBase
    {
        //https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt

        #region Relationship
        public List<RoleGroup> RoleGroups { get; set; }

        public List<Medical> MedicalsCreateds { get; set; }

        public List<Medical> MedicalModifies { get; set; }

        public List<Medical> MedicalsUsers { get; set; }


        #endregion Relationship

        #region Columns 

        [Column("Login", Order = 4, TypeName = "varchar(25)")]
        [MaxLength(25)] 
        [Required] 
        public string Login { get; set; }

        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }
        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [Column("Role", TypeName = "varchar(50)")]
        [MaxLength(50)] 

        public string Role { get; set; }

        public bool Admin { get; set; }

        [Column("Language", TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string? Language { get; set; }

        [Column("TimeZone", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? TimeZone { get; set; }
        
        [Column("Refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("Refresh_token_expiry_time")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        #endregion Columns 
    }
}