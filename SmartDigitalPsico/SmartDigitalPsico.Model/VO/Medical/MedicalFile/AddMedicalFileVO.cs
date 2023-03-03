using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class AddMedicalFileVO : FileBaseVO, IEntityVOAdd
    {
        [Required]
        public long IdUserAction { get; set; }

        #region Relationship 
        [Required]
        public long MedicalId { get; set; }

        #endregion Relationship 
    }
}