using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class AddMedicalVO : EntityVOBase , IEntityVOUserLog
    {
        #region Relationship
        [Required]
        public long OfficeId { get; set; }
        [MaxLength(20)]

        [Required]
        public long IdUserAction { get; set; }

        [Required] 
        public List<long> SpecialtiesIds { get; set; }

        #endregion Relationship

        #region Columns

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