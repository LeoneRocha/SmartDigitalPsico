using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientServices : IGenericServicesEntityBaseSimple<Patient, GetPatientVO>
    {
        Task<ServiceResponse<GetPatientVO>> Create(AddPatientVO item);

        Task<ServiceResponse<GetPatientVO>> FindByPatient(GetPatientVO info);
    }
}