using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class AddMedicalFileVOUpload : IEntityVOAdd
    // FileBaseVO, 
    {
        #region Relationship 
        [Required]
        public long MedicalId { get; set; }
        public IFormFile FileDetails { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        #endregion Relationship 
    }
}