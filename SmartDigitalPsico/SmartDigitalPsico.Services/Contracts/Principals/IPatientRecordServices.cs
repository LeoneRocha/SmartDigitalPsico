using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientRecordServices : IGenericServicesEntityBaseSimple<PatientRecord, AddPatientRecordVO, UpdatePatientRecordVO, GetPatientRecordVO>
    { 
        Task<ServiceResponse<List<GetPatientRecordVO>>> FindAllByPatient(long patientId);
    }
}