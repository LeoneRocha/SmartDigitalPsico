using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Patient", Schema = "dbo")]
    public class Patient : EntityBase
    {
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("DateOfBirth")]
        public Gender Gender { get; set; }

        [Column("Profession")]
        [AllowNull]
        public string Profession { get; set; }


        /*Date Of Birth :
        Gender:
        Cpf:
        Rg:
        Profession
        Education:
        Marital Status
        Telephone
        Email
        Address
        Neighborhood
        City
        State*/
    }
}