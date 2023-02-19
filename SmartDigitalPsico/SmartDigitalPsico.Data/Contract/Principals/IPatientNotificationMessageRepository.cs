using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientNotificationMessageRepository : IRepositoryEntityBaseSimple<PatientNotificationMessage>
    {
        Task<List<PatientNotificationMessage>> FindAllByPatient(long patientId);
    }
}
