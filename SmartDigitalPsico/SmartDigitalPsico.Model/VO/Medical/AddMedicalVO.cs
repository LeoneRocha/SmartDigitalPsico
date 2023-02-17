using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;

namespace SmartDigitalPsico.Model.VO.User
{
    public class AddMedicalVO : IEntityVOUserLog
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long IdUserAction { get; set; }

        public long IdOffice { get; set; }
        public List<long> IdsSpecialties { get; set; }
 
        public string Accreditation { get; set; }

        public ETypeAccreditation TypeAccreditation { get; set; }
        
    }
}