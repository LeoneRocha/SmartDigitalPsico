using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class GetMedicalFileVO : FileBaseIDVO, ISupportsHyperMedia
    {
        #region Relationship  
        public GetMedicalVO Medical { get; set; }

        #endregion Relationship
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}