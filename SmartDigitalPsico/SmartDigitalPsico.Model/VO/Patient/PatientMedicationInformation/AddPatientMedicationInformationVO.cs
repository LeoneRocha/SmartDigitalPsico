using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation
{
    public class AddPatientMedicationInformationVO : IEntityVOAdd
    {
        [Required]
        public long IdUserAction { get; set; }
         

        #region Relationship 
        [Required]
        public long PatientId { get; set; }

        #endregion Relationship

        #region Columns 

        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(255)]
        public string? Dosage { get; set; }

        [MaxLength(255)]
        public string? Posology { get; set; }

        [MaxLength(255)]
        public string? MainDrug { get; set; }

        #endregion Columns  
    }
}