using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("MedicalFile", Schema = "dbo")]
    public class MedicalFile : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship 
         [Required]
         public Medical Medical { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns  
        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string? Description { get; set; }
         
        [Column("FilePath", TypeName = "varchar(2083)")]
        [MaxLength(2083)]        
        public string? FilePath { get; set; }

        [Column("FileData")]
        public byte[]? FileData { get; set; }


        #endregion Columns 
    }
}