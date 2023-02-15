using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("User", Schema = "dbo")]
    public class User : EntityBaseLog
    {
        //https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }

        public List<RoleGroup> RoleGroups { get; set; }
    }
}