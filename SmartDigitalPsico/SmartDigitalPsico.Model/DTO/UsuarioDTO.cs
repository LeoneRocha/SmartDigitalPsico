using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
    
        public string Nome { get; set; }
        public byte[] Password{ get; set; }  

        public string Role { get; set; }
    }
}