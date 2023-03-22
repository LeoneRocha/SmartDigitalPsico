using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalBusiness
        : IGenericBusinessEntityBaseV2<Medical, AddMedicalVO, UpdateMedicalVO, GetMedicalVO>
    {

    }
}