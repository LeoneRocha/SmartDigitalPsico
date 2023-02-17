using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Model.Contracts.Interface
{
    public interface IEntityVOUserLog
    {
        long Id { get; set; }
        long IdUserAction { get; set; }

    }
}