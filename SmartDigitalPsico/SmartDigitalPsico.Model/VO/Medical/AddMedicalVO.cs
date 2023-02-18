using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class AddMedicalVO : ISupportsHyperMedia, IEntityVOUserLog
    {
        #region Relationship
        [Required]
        public long OfficeId { get; set; }
        [MaxLength(20)]

        [Required]
        public long IdUserAction { get; set; }

        [Required]
        public List<long> SpecialtiesIds { get; set; }

        #endregion Relationship

        #region Columns
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Accreditation { get; set; }

        public ETypeAccreditation TypeAccreditation { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
        #endregion Columns  
    }
}