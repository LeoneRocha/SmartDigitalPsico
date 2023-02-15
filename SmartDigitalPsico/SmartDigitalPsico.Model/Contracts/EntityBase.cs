using SmartDigitalPsico.Domains.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }

        public bool Enable { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; }

        public DateTime DateLasAcess { get; set; }

    }
}