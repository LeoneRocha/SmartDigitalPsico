using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.Dto.User
{
    public class AddMedicalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdUserAction { get; set; }

        public int IdOffice { get; set; }
        public List<int> IdsSpecialties { get; set; }
 
        public string Accreditation { get; set; }

        public ETypeAccreditation TypeAccreditation { get; set; }
        
    }
}