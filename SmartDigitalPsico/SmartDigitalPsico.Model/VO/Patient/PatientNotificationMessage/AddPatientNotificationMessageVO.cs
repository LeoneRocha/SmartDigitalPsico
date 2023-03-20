using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage
{
    public class AddPatientNotificationMessageVO : IEntityVOAdd
    {
        [Required]
        public long IdUserAction { get; set; }


        #region Columns  
        [MaxLength(2000)]
        [Required]
        public string Message { get; set; }

        [MaxLength(15)]
        public string? Cpf { get; set; }

        [MaxLength(15)]
        public string Rg { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        #endregion Columns  
    }
}