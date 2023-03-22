using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientServices : IGenericServicesEntityBase<Patient, GetPatientVO>
    {
        Task<ServiceResponse<GetPatientVO>> Create(AddPatientVO item);
        Task<ServiceResponse<GetPatientVO>> FindByPatient(GetPatientVO info);
        Task<ServiceResponse<List<GetPatientVO>>> FindAll(long medicalId); 
    }
}