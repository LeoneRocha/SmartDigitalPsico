using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Medical;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IMedicalService : IGenericServicesEntityBase<Medical, GetMedicalVO>
    { 
        Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item);
    }
}