using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IMedicalService : IGenericServicesEntityBase<Medical, GetMedicalDto>
    { 
        Task<ServiceResponse<GetMedicalDto>> Create(AddMedicalDto item);
    }
}