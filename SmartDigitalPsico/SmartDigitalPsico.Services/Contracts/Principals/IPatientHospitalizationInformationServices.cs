using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IPatientHospitalizationInformationServices : IGenericServicesEntityBaseSimpleV2<PatientHospitalizationInformation, AddPatientHospitalizationInformationVO, UpdatePatientHospitalizationInformationVO, GetPatientHospitalizationInformationVO>
    {

        Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId);
    }
}