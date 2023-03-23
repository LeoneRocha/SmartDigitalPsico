using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class AddUserVO : EntityVOBaseAdd
    {
        #region Relationship
        public List<long>? RoleGroupsIds { get; set; }

        public long? MedicalId { get; set; }

        #endregion Relationship
         
        public string Name { get; set; }
         
        public string Email { get; set; }
         
        public string Login { get; set; }
         
        public string Password { get; set; }

        #region Columns  
          
        public string? Role { get; set; }

        public bool? Admin { get; set; }

        public string? Language { get; set; }

        public string? TimeZone { get; set; }


        #endregion Columns 
    }
}