using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Contracts
{
    public abstract class EntityVOBaseAdd : IEntityVOAdd
    { 

        public bool Enable { get; set; }
    }
}