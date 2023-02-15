using SmartDigitalPsico.Domains.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBase
    {
        [Column("Id")] 
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }
        [Column("Enable")]
        public bool Enable { get; set; } 

    }
}