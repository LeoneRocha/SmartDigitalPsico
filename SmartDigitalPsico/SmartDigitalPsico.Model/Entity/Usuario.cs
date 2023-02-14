using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<RoleGroup> RoleGroups { get; set; }

        public string Role { get; set; }
    }
}