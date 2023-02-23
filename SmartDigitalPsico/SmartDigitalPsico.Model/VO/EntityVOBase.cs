using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO
{
    public abstract class EntityVOBase  : IEntityVO
    {
        public long Id { get; set; } 

        public bool Enable { get; set; } 

    }
}