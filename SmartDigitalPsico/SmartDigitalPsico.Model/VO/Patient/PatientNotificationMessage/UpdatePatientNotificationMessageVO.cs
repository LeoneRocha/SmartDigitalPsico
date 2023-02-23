using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage
{
    public class UpdatePatientNotificationMessageVO : ISupportsHyperMedia, IEntityVOUserLog, IEntityVO
    {
        [Required]
        public long IdUserAction { get; set; }

        [Required]
        public long Id { get; set; }
        public bool Enable { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

        #region Columns  
        [MaxLength(2000)]
        [Required]
        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public bool Notified { get; set; }

        #endregion Columns  
    }
}