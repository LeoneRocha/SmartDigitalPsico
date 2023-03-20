using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Utils;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SmartDigitalPsico.Model.VO.User
{
    public class GetUserAuthenticatedVO : EntityVOBase 
    {
        public GetUserAuthenticatedVO()
        {
            TokenAuth = new TokenVO();
        }          
        public string Name { get; set; }
        public TokenVO TokenAuth { get; set; }
        public List<GetRoleGroupVO> RoleGroups { get; set; }
    }
}