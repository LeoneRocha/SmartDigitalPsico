using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Medical;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class GetUserVO : EntityVOBaseName, ISupportsHyperMedia
    {
        #region Relationship
        public List<GetRoleGroupVO> RoleGroups { get; set; }

        public long? MedicalId { get; set; }

        public GetMedicalVO Medical { get; set; }

        #endregion Relationship


        public string Login { get; set; }
          
        #region Columns  

        public string? Role { get; set; }

        public bool? Admin { get; set; }

        public string? Language { get; set; }

        public string? TimeZone { get; set; }
         
        #endregion Columns 
          
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}