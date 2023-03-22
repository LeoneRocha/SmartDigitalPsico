using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class UpdateMedicalVO : EntityVOBase 
    {
        #region Relationship
        [Required]
        public long OfficeId { get; set; }
        [MaxLength(20)]
         

        [Required]
        public List<long> SpecialtiesIds { get; set; }

        #endregion Relationship

        #region Columns
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Accreditation { get; set; }

        public ETypeAccreditation TypeAccreditation { get; set; }
         
        #endregion Columns  
    }
}