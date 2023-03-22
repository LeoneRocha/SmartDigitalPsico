using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation
{
    public class AddPatientAdditionalInformationVO : IEntityVOAdd
    { 

        #region Relationship 
        [Required]
        public long PatientId { get; set; }

        #endregion Relationship

        #region Columns 

        public string FollowUp_Psychiatric { get; set; }

        public string FollowUp_Neurological { get; set; }

        #endregion Columns 

    }
}