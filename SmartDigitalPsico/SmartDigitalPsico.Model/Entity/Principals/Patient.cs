using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Patients", Schema = "dbo")]
    public class Patient : EntityBase
    {
        #region Relationship
        [Required] 
        public Medical Medical { get; set; }
        public List<PatientAdditionalInformation> PatientAdditionalInformations { get; set; }
        public List<PatientHospitalizationInformation> PatientHospitalizationInformations { get; set; }
        public List<PatientMedicationInformation> PatientMedicationInformations { get; set; }
        public List<PatientRecord> PatientRecords { get; set; }

        #endregion Relationship
         
        #region Columns
          
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        public Gender Gender { get; set; }

        [Column("Profession")]
        public string Profession { get; set; }

        [Column("Cpf", TypeName = "varchar(15)")]
        public string? Cpf { get; set; }

        [Column("Rg", TypeName = "varchar(15)")]
        public string? Rg { get; set; }

        [Column("Education", TypeName = "varchar(255)")]
        public string? Education { get; set; }

        [Column("PhoneNumber", TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }

        [Column("AddressStreet", TypeName = "varchar(255)")]
        public string? AddressStreet { get; set; }

        [Column("AddressNeighborhood", TypeName = "varchar(255)")]
        public string? AddressNeighborhood { get; set; }

        [Column("AddressCity", TypeName = "varchar(255)")]
        public string? AddressCity { get; set; }

        [Column("AddressState", TypeName = "varchar(255)")]
        public string? AddressState { get; set; }

        [Column("AddressCep", TypeName = "varchar(20)")]
        public string? AddressCep { get; set; }

        [Column("EmergencyContactName", TypeName = "varchar(255)")]
        public string? EmergencyContactName { get; set; }

        [Column("EmergencyContactPhoneNumber", TypeName = "varchar(20)")]
        public string? EmergencyContactPhoneNumber { get; set; }
        #endregion
    }
}