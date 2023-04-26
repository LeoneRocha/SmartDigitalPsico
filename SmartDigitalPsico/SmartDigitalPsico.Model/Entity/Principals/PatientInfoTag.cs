using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientInfoTag", Schema = "dbo")]
    public class PatientInfoTag
    {
        //[Column("Id", Order = 0)]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
         
        #region Relationship 
        public InfoTag InfoTag { get; set; }

        public long InfoTagId { get; set; }

        public Patient Patient { get; set; }

        public long PatientId { get; set; }

        #endregion Relationship 
    }
}