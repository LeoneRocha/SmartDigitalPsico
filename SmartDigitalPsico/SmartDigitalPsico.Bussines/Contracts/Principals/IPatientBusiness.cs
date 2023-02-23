using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IPatientBusiness
    {
 

        Task<ServiceResponse<GetPatientVO>> FindByPatient(GetPatientVO info);
    }
}