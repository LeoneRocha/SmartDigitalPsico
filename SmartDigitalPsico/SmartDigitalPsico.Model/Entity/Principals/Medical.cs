using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Medical", Schema = "dbo")]
    public class Medical : EntityBaseLog
    {
        public Office Office { get; set; }

        public List<Specialty> Specialties { get; set; }

        public User User { get; set; }

        [Column("Accreditation")]
        public string Accreditation { get; set; }

        [Column("TypeAccreditation")]
        public ETypeAccreditation TypeAccreditation { get; set; }
    }
}