using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation
{
    public class GetPatientAdditionalInformationVO : EntityVOBase, ISupportsHyperMedia
    { 
       
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