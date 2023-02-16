using SmartDigitalPsico.Model.Entity.Principals;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.Contracts.Interface
{
    public interface IEntityBaseDomains
    {
        string Description { get; set; }

        string Language { get; set; }

    }
}