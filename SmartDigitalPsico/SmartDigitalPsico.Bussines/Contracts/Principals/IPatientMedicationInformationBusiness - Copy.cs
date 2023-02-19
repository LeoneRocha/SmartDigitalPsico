using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientNotificationMessageBusiness : IGenericBusinessEntityBaseSimple<PatientNotificationMessage, GetPatientNotificationMessageVO>
    {
        Task<ServiceResponse<GetPatientNotificationMessageVO>> Create(AddPatientNotificationMessageVO item);
        Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId);
    }
}