using SmartDigitalPsico.Domains.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public interface IEntityBaseLog
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; } 
        public DateTime DateLasAcess { get; set; }

    }
}