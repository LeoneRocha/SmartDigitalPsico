using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Contract.Model
{
    public interface IEntityBaseLogUser
    {

        User? CreatedUser { get; set; }

        User? ModifyUser { get; set; }

    }
}