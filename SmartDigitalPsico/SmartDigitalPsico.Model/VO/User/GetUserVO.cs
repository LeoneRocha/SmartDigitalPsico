using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.User
{
    public class GetUserVO : EntityVOBase
    {  
        public string TokenAuth { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

    }
}