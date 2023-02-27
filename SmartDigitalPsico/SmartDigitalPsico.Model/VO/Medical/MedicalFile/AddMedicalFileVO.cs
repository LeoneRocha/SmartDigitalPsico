using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class AddMedicalFileVO : IEntityVOAdd
    {
        [Required]
        public long IdUserAction { get; set; }
         
        #region Relationship 
        [Required]
        public long MedicalId { get; set; }

        #endregion Relationship

        #region Columns 
         
        [MaxLength(255)] 
        public string? Description { get; set; }
         
        [MaxLength(2083)]
        [Required]
        public string FilePath { get; set; }

        #endregion Columns  
    }
}