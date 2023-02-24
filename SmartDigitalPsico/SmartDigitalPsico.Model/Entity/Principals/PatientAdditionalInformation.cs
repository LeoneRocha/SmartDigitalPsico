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
    [Table("PatientAdditionalInformations", Schema = "dbo")]
    public class PatientAdditionalInformation : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship
        [Required]
        public Patient Patient { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns 

        [Column("FollowUp_Psychiatric", TypeName = "varchar(2000)")]
        [MaxLength(2000)]
        public string? FollowUp_Psychiatric { get; set; }

        [Column("FollowUp_Neurological", TypeName = "varchar(2000)")]
        [MaxLength(2000)]
        public string? FollowUp_Neurological { get; set; }

        #endregion Columns 
    }
}