using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation
{
    public class GetPatientAdditionalInformationVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        //MUDAR AS RELACOES PARA OBJETOS  
        #region Relationship  
        public GetPatientVO Patient { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        #endregion Relationship

        #region Columns 

        public string FollowUp_Psychiatric { get; set; }

        public string FollowUp_Neurological { get; set; }

        #endregion Columns 
    }
}