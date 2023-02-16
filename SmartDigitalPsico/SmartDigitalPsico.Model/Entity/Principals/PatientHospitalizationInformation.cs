using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("PatientHospitalizationInformations", Schema = "dbo")]
    public class PatientHospitalizationInformation : EntityBaseSimple, IEntityBaseLogUser
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

        [Column("CID", TypeName = "varchar(20)")]
        public string CID { get; set; }
         
        [Column("Observation", TypeName = "varchar(max)")]
        public string Observation { get; set; }
         
        #endregion Columns 
    }
}