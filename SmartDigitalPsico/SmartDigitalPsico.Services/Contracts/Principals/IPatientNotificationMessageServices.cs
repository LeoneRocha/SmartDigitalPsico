using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientNotificationMessageServices : IGenericServicesEntityBaseSimple<PatientNotificationMessage, GetPatientNotificationMessageVO>
    {
        Task<ServiceResponse<GetPatientNotificationMessageVO>> Create(AddPatientNotificationMessageVO item);
        Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId);
    }
}