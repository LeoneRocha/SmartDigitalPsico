using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Contract.Model
{
    public interface IEntityBaseLog
    {

        DateTime CreatedDate { get; set; }

        DateTime ModifyDate { get; set; }

        DateTime LastAccessDate { get; set; }

    }
}