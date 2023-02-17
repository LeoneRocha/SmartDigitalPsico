using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalBusiness : IGenericBusinessEntityBase<Medical, GetMedicalDto>
    {
        Task<ServiceResponse<GetMedicalDto>> Create(AddMedicalDto item);
    }
}