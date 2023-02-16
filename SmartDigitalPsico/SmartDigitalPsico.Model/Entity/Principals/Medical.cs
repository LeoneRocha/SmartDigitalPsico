using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Medicals", Schema = "dbo")]
    public class Medical : EntityBase
    {
        #region Relationship
        [Required] 
        public Office Office { get; set; }
        [Required] 
        public User User { get; set; }
        public List<Specialty> Specialties { get; set; }
        public List<Patient> Patienties { get; set; }

        #endregion Relationship

        #region Columns
          
        [Column("Accreditation")]
        public string Accreditation { get; set; }

        [Column("TypeAccreditation")]
        public ETypeAccreditation TypeAccreditation { get; set; }
        #endregion Columns 
    }
}