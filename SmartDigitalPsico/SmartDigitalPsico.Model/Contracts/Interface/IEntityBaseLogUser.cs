using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Model.Contracts.Interface
{
    public interface IEntityBaseLogUser
    {

        User? CreatedUser { get; set; }

        User? ModifyUser { get; set; }

    }
}