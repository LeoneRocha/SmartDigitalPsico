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
    [Table("PatientNotificationMessage", Schema = "dbo")]
    public class PatientNotificationMessage : EntityBaseSimple, IEntityBaseLogUser
    {
        #region Relationship 
        [Required] 
        public Patient Patient { get; set; }
        public User? CreatedUser { get; set; }
        public User? ModifyUser { get; set; }
        #endregion Relationship

        #region Columns 
        [Column("MessagePatient", TypeName = "varchar(2000)")] 
        [MaxLength(2000)]
        [Required]
        public string MessagePatient { get; set; }

        [Column("IsReaded")]
        public bool IsReaded { get; set; }

        [Column("ReadingDate")]
        public DateTime ReadingDate { get; set; }
         
        [Column("Notified")]
        public bool Notified { get; set; }
         
        [Column("NotifiedDate")]
        public DateTime NotifiedDate { get; set; }

        #endregion Columns 
    }
}