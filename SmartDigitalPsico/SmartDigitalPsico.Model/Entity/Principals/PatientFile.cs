using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientFile", Schema = "dbo")]
    public class PatientFile : FileBase, IEntityBaseLogUser
    {
        #region Relationship 
        //[Required]
        public Patient Patient { get; set; }

        [ForeignKey("PatientId")]
        public long PatientId { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

    }
}