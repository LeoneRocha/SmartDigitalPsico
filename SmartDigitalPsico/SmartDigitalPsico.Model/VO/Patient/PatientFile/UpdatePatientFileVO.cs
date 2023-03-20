using System.ComponentModel.DataAnnotations;
using SmartDigitalPsico.Model.VO.Contracts;

namespace SmartDigitalPsico.Model.VO.Patient.PatientFile
{
    public class UpdatePatientFileVO : EntityVOBase
    {
        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(2083)]
        [Required]
        public string FilePath { get; set; }
    }
}