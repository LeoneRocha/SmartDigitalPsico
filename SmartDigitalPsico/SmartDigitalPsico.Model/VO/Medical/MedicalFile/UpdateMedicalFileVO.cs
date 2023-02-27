using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical.MedicalFile
{
    public class UpdateMedicalFileVO : EntityVOBase
    {
        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(2083)]
        [Required]
        public string FilePath { get; set; }
    }
}