using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientHospitalizationInformationBusiness : IGenericBusinessEntityBaseSimple<PatientHospitalizationInformation, GetPatientHospitalizationInformationVO>
    {
        Task<ServiceResponse<GetPatientHospitalizationInformationVO>> Create(AddPatientHospitalizationInformationVO item);
        Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId);
    }
}