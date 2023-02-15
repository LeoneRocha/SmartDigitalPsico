using SmartDigitalPsico.Dominio.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Medical", Schema = "dbo")]
    public class Medical : EntityBase
    {
        public Office Office { get; set; }
        public List<Specialty> Specialties { get; set; }

        public User User { get; set; }
        public string Accreditation { get; set; }

        public ETypeAccreditation TypeAccreditation { get; set; }
    }
}