using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Medical;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class UpdateUserProfileVO : EntityVOBaseName 
    {

        #region Relationship 
        public UpdateMedicalVO? Medical { get; set; }

        #endregion Relationship

        #region Columns  
        public string? Password { get; set; }
          
        public string? Language { get; set; }

        public string? TimeZone { get; set; }

        #endregion Columns 


    }
}