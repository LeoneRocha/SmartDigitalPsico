using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientFileBusiness : IGenericBusinessEntityBaseSimpleV2<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO>
    {
       
    }
}