using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Model.Dto.User
{
    public class UpdateUserDto : EntityDTOBase
    {
 
        public string Name { get; set; } 
        public string Email { get; set; }
      
    }
}