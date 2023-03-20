using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class AddMedicalFileVO : FileBaseVO, IEntityVOAdd
    { 
        #region Relationship 
        [Required]
        public long MedicalId { get; set; }
        public IFormFile FileDetails { get; set; }
        
        public long IdUserAction { get; set; }


        #endregion Relationship 
    }
}