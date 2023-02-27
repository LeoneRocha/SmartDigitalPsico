using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientHospitalizationInformationBusiness : IGenericBusinessEntityBaseSimpleV2<PatientHospitalizationInformation, AddPatientHospitalizationInformationVO ,UpdatePatientHospitalizationInformationVO , GetPatientHospitalizationInformationVO>
    { 

        Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId);
    }
}