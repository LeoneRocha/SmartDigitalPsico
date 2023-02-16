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

        #endregion Relationship

        #region Columns 

        [Column("Login", Order = 4)]
        public string? Login { get; set; }

        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }
        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [Column("Role")]
        public string Role { get; set; }


        #endregion Columns 
    }
}