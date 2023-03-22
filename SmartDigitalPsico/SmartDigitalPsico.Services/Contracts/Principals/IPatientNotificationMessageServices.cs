using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientNotificationMessageServices
        : IGenericServicesEntityBaseSimple<PatientNotificationMessage, AddPatientNotificationMessageVO, UpdatePatientNotificationMessageVO, GetPatientNotificationMessageVO>
    { 
        
        Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId);
    }
}