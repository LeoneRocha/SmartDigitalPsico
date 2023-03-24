using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientRecords", Schema = "dbo")]
    public class PatientRecord : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship 
        [Required]
        public Patient Patient { get; set; }

        [ForeignKey("PatientId")]
        public long PatientId { get; set; }

        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns 

        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [Column("Annotation")] 
        [Required]
        public string Annotation { get; set; }
         
        [Column("AnnotationDate")]
        public DateTime AnnotationDate { get; set; }
           
        #endregion Columns 
    }
}