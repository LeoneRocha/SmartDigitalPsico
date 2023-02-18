using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientAdditionalInformationBusiness : IGenericBusinessEntityBaseSimple<PatientAdditionalInformation, GetPatientAdditionalInformationVO>
    {
        Task<ServiceResponse<GetPatientAdditionalInformationVO>> Create(AddPatientAdditionalInformationVO item);
        Task<ServiceResponse<List<GetPatientAdditionalInformationVO>>> FindAllByPatient(long patientId);
    }
}