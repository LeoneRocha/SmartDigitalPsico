using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        //https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }
         
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }

        public List<RoleGroup> RoleGroups { get; set; }
    }
}