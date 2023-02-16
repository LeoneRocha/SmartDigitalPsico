using SmartDigitalPsico.Domains.Enuns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityDTOBaseSimple
    {
         
        public long Id { get; set; }
         
        public string Description { get; set; }
 
        public string Language { get; set; }

    }
}