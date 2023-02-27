using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientFile", Schema = "dbo")]
    public class PatientFile : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship 
        //[Required]
        public Patient Patient { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns  
        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)] 
        public string? Description { get; set; }
         
        [Column("FilePath", TypeName = "varchar(2083)")]
        [MaxLength(2083)]
        [Required]
        public string FilePath { get; set; } 
        #endregion Columns 
    }
}