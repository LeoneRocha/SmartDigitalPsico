using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Model.Dto.User
{
    public class GetUserDto : EntityDTOBase
    {  
        public string TokenAuth { get; set; }

    }
}