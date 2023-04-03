using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class UpdateUserVO : EntityVOBaseName 
    {
        #region Relationship
        public List<long>? RoleGroupsIds { get; set; }

        public long? MedicalId { get; set; }

        #endregion Relationship

        #region Columns  
        public string Password { get; set; }

        public string? Role { get; set; }

        public bool? Admin { get; set; }

        public string? Language { get; set; }

        public string? TimeZone { get; set; }

        #endregion Columns 


    }
}