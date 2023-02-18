using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class AddPatientVO : BasePatientVO
    {  
        #region Relationship
  
        public long MedicalId { get; set; } 

        #endregion Relationship
         

    }
}