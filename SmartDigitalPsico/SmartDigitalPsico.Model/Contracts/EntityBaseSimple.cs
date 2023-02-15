using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBaseSimple
    {
        [Column("Id")] 
        public long Id { get; set; }

        [Column("Description", TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Column("Language", TypeName = "char(5)")]
        [MaxLength(5)]
        public string Language { get; set; }

    }
}
