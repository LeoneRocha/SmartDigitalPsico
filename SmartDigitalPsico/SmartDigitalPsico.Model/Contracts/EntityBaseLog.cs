using SmartDigitalPsico.Domains.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBaseLog : EntityBase, IEntityBaseLog
    {
        [Column("DateCreated")] 
        public  DateTime DateCreated { get; set; }
        [Column("DateModify")]
        public  DateTime DateModify { get; set; }
        [Column("DateLastAcess")]
        public  DateTime DateLastAcess { get; set; }
    }
}