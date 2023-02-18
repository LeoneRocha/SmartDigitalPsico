using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalBusiness : IGenericBusinessEntityBase<Medical, GetMedicalVO>
    {
        Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item);
    }
}