using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage
{
    public class UpdatePatientNotificationMessageVO : EntityVOBase
    {
        [Required]
        public long IdUserAction { get; set; }
           
        #region Columns  
        [MaxLength(2000)]
        [Required]
        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public bool Notified { get; set; }

        #endregion Columns  
    }
}