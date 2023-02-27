using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation
{
    public class UpdatePatientHospitalizationInformationVO : EntityVOBase
    {

        #region Columns 

        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(20)]
        [Required]
        public string CID { get; set; }

        [Required]
        public string Observation { get; set; }

        #endregion Columns 
    }
}