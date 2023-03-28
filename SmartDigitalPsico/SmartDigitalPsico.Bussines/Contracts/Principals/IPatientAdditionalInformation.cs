using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientAdditionalInformationBusiness : IGenericBusinessEntityBaseSimple<PatientAdditionalInformation, 
        AddPatientAdditionalInformationVO,UpdatePatientAdditionalInformationVO, GetPatientAdditionalInformationVO>
    {
        //Task<ServiceResponse<GetPatientAdditionalInformationVO>> Create(AddPatientAdditionalInformationVO item);
        Task<ServiceResponse<List<GetPatientAdditionalInformationVO>>> FindAllByPatient(long patientId);
    }
}