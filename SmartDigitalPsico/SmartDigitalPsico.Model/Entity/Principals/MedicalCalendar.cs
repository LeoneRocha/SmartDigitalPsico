using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("MedicalCalendar", Schema = "dbo")]
    public class MedicalCalendar : FileBase, IEntityBaseLogUser
    {
        #region Relationship 
        [Required]
        public Medical Medical { get; set; }

        [ForeignKey("MedicalId")]
        public long MedicalId { get; set; }


        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns 

        [Column("Title", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [Column("AllDay")]
        public bool AllDay { get; set; }

        [Column("ColorCategory", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string ColorCategory { get; set; }

        [Column("Url", TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string Url { get; set; }

        [Column("PushedCalendar")]
        public bool PushedCalendar { get; set; }

        [Column("TimeZone", TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string? TimeZone { get; set; } 
        #endregion Columns 
    }
}