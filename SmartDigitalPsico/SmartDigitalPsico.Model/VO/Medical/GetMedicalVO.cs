using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.VO.Patient;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class GetMedicalVO : EntityVOBase 
    {
        //MUDAR AS RELACOES PARA OBJETOS 

        #region Relationship

        public long OfficeId { get; set; }
         

        public List<long> SpecialtiesIds { get; set; }

        public List<GetPatientVO> Patients { get; set; }

        #endregion Relationship

        #region Columns

        public string Email { get; set; }
        public string Accreditation { get; set; }
        public ETypeAccreditation TypeAccreditation { get; set; }

        #endregion Columns  
    }
}