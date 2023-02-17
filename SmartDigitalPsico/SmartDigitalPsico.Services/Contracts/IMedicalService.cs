using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IMedicalService : IGenericServicesEntityBase<Medical, GetMedicalVO>
    { 
        Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item);
    }
}