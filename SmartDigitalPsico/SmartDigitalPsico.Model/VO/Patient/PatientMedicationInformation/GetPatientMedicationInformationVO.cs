using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation
{
    public class GetPatientMedicationInformationVO : EntityVOBase, ISupportsHyperMedia
    {
        public long Id { get; set; }
        //MUDAR AS RELACOES PARA OBJETOS  
        #region Relationship  
        public GetPatientVO Patient { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        #endregion Relationship

        #region Columns 

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Dosage { get; set; }

        public string? Posology { get; set; }

        public string? MainDrug { get; set; }

        #endregion Columns   
    }
}