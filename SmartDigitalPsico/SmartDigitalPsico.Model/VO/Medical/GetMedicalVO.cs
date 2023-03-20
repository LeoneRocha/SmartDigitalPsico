using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Patient;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class GetMedicalVO : EntityVOBase, ISupportsHyperMedia
    {
        //MUDAR AS RELACOES PARA OBJETOS 

        #region Relationship

        public GetOfficeVO Office { get; set; }
          
        public List<GetSpecialtyVO> Specialties { get; set; }

        public List<GetPatientVO> Patients { get; set; }

        #endregion Relationship

        #region Columns

        public string Email { get; set; }
        public string Accreditation { get; set; }
        public ETypeAccreditation TypeAccreditation { get; set; }

        #endregion Columns  

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}