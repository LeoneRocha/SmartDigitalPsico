using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class UpdatePatientVO : EntityVOBase
    {
        public long Id { get; set; }
        public bool Enable { get; set; }
         
        #region Columns
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(255)]
        public string? Profession { get; set; }

        [MaxLength(15)]
        public string? Cpf { get; set; }

        [Required]
        [MaxLength(15)]
        public string Rg { get; set; }

        [MaxLength(255)]
        public string? Education { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(255)]
        public string? AddressStreet { get; set; }

        [MaxLength(255)]
        public string? AddressNeighborhood { get; set; }

        [MaxLength(255)]
        public string? AddressCity { get; set; }

        [MaxLength(255)]
        public string? AddressState { get; set; }

        [MaxLength(20)]
        public string? AddressCep { get; set; }

        [MaxLength(255)]
        public string? EmergencyContactName { get; set; }

        [MaxLength(20)]
        public string? EmergencyContactPhoneNumber { get; set; }


        #endregion 
    }
}