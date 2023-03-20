using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientRecord
{
    public class AddPatientRecordVO : IEntityVOAdd
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

        [Required]
        public string Annotation { get; set; }
        [Required]
        public DateTime AnnotationDate { get; set; }

        #endregion Columns  
    }
}