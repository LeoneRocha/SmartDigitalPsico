using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientFile
{
    public class GetPatientFileVO : EntityVOBase, ISupportsHyperMedia
    { 
        #region Relationship  
        public GetPatientVO Patient { get; set; }

        #endregion Relationship

        #region Columns  

        public string  Description { get; set; }
         
        public string FilePath { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        
        public string FileName { get; set; }

        #endregion Columns  

    }
}