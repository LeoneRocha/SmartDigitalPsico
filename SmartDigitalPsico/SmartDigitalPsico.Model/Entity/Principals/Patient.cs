using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Entity.Principals
{
    [Table("Patient", Schema = "dbo")]
    public class Patient : EntityBase
    {

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

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