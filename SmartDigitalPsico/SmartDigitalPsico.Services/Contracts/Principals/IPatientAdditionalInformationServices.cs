using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientAdditionalInformationServices : IGenericServicesEntityBaseSimpleV2<PatientAdditionalInformation, AddPatientAdditionalInformationVO, UpdatePatientAdditionalInformationVO, GetPatientAdditionalInformationVO>
    {

        Task<ServiceResponse<List<GetPatientAdditionalInformationVO>>> FindAllByPatient(long patientId);
    }
}