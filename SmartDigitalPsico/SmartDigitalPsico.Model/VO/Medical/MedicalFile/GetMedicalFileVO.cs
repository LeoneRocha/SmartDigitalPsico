using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class GetMedicalFileVO : EntityVOBase, ISupportsHyperMedia
    { 
        #region Relationship  
        public GetMedicalVO Medical { get; set; }

        #endregion Relationship

        #region Columns  

        public string  Description { get; set; }
         
        public string FilePath { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        #endregion Columns  

    }
}