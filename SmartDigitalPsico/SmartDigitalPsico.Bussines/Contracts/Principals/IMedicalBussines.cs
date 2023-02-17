using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalBusiness : IGenericBusinessEntityBase<Medical, GetMedicalVO>
    {
        Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item);
    }
}