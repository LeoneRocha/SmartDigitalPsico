using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage
{
    public class GetPatientNotificationMessageVO : EntityVOBase, ISupportsHyperMedia
    {
     
        //MUDAR AS RELACOES PARA OBJETOS  
        #region Relationship  
        public GetPatientVO Patient { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        #endregion Relationship

        #region Columns 

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public DateTime ReadingDate { get; set; }

        public bool Notified { get; set; }

        public DateTime NotifiedDate { get; set; }

        #endregion Columns 


    }
}