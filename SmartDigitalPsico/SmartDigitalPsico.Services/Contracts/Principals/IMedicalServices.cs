using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IMedicalServices
     //   : IGenericServicesEntityBase<Medical, GetMedicalVO>
    : IGenericServicesEntityBaseV2<Medical, AddMedicalVO, UpdateMedicalVO, GetMedicalVO>
    {

    }
}