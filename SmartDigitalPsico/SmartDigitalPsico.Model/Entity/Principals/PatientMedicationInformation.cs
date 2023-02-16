using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientMedicationInformations", Schema = "dbo")]
    public class PatientMedicationInformation : EntityBaseSimple
    {
        #region Relationship
       
        public Patient Patient { get; set; }

        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }

        #endregion Relationship

        #region Columns 

        [Column("Description", TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }
         
        [Column("EndDate")]
        public DateTime? EndDate { get; set; }
         
        [Column("Dosage", TypeName = "varchar(255)")]
        public string? Dosage { get; set; }

        [Column("Posology", TypeName = "varchar(255)")]
        public string? Posology { get; set; }

        /// <summary>
        /// Fármaco
        /// </summary>
        [Column("MainDrug", TypeName = "varchar(255)")]
        public string? MainDrug { get; set; }

        #endregion Columns 
    }
}