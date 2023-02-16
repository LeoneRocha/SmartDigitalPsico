using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Model.Contracts.Interface
{
    public interface IEntityBaseLog
    {

        DateTime CreatedDate { get; set; }

        DateTime ModifyDate { get; set; }

        DateTime LastAccessDate { get; set; }

    }
}