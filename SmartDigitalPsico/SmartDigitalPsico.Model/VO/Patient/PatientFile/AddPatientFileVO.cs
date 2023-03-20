using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientFile
{
    public class AddPatientFileVO : FileBaseVO, IEntityVOAdd 
    {
        #region Relationship 
        [Required]
        public long PatientId { get; set; }
        public IFormFile FileDetails { get; set; }

        public long IdUserAction { get; set; }


        #endregion Relationship
    }
}