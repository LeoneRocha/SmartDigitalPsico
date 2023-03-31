using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Patients", Schema = "dbo")]
    public class Patient : EntityBase, IEntityBaseLogUser
    {
        #region Relationship  
        //public ICollection<InfoTag> InfoTags { get; set; }
        //public List<InfoTag> InfoTags { get; } = new();
        //public ICollection<InfoTag> InfoTags { get; set; }
        //public List<PatientInfoTag> PatientInfoTags { get; set; }
        public List<PatientInfoTag> PatientInfoTags { get; set; }


        [Required]
        public Medical Medical { get; set; }

        [ForeignKey("MedicalId")]
        public long MedicalId { get; set; }

        public List<PatientAdditionalInformation> PatientAdditionalInformations { get; set; }
        public List<PatientHospitalizationInformation> PatientHospitalizationInformations { get; set; }
        public List<PatientMedicationInformation> PatientMedicationInformations { get; set; }
        public List<PatientRecord> PatientRecords { get; set; }

        public User? CreatedUser { get; set; }

        [ForeignKey("CreatedUserId")]
        public long? CreatedUserId { get; set; }

        public User? ModifyUser { get; set; }

        [ForeignKey("ModifyUserId")]
        public long? ModifyUserId { get; set; }

        [Column("Gender")]
        public Gender Gender { get; set; }

        [ForeignKey("GenderId")]
        public long GenderId { get; set; }
        #endregion Relationship

        #region Columns

        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("Profession", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? Profession { get; set; }

        [Column("Cpf", TypeName = "varchar(15)")]
        [MaxLength(15)]
        public string? Cpf { get; set; }

        [Column("Rg", TypeName = "varchar(15)")]
        [Required]
        [MaxLength(15)]
        public string Rg { get; set; }

        [Column("Education", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? Education { get; set; }

        [Column("PhoneNumber", TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Column("AddressStreet", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? AddressStreet { get; set; }

        [Column("AddressNeighborhood", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? AddressNeighborhood { get; set; }

        [Column("AddressCity", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? AddressCity { get; set; }

        [Column("AddressState", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? AddressState { get; set; }

        [Column("AddressCep", TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string? AddressCep { get; set; }

        [Column("EmergencyContactName", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? EmergencyContactName { get; set; }

        [Column("EmergencyContactPhoneNumber", TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string? EmergencyContactPhoneNumber { get; set; }

        #endregion
    }
}