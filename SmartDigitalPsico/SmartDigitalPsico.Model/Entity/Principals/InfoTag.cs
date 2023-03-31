using Microsoft.Extensions.Hosting;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("InfoTag", Schema = "dbo")]
    public class InfoTag : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship 
        [Required]
        public Medical Medical { get; set; }

        [ForeignKey("MedicalId")]
        public long MedicalId { get; set; }

        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }

        [ForeignKey("CreatedUserId")]
        public long? CreatedUserId { get; set; }

        [ForeignKey("ModifyUserId")]
        public long? ModifyUserId { get; set; }

        //public ICollection<Patient> Patients { get; set; }

        // public ICollection<Patient> Patients { get; set; }
        public List<PatientInfoTag> PatientInfoTags { get; set; }


        //public List<Patient> Patients { get; set; }

        // public List<PatientRecord> PatientRecords { get; set; }



        #endregion Relationship

    }
}