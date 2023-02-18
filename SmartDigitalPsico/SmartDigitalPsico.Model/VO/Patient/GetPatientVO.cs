using SmartDigitalPsico.Domains.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Medical;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class GetPatientVO : EntityVOBase 
    {
        //MUDAR AS RELACOES PARA OBJETOS 
        #region Relationship
        [Required]
        public GetMedicalVO Medical { get; set; }
        public List<long> PatientAdditionalInformations { get; set; }
        public List<long> PatientHospitalizationInformations { get; set; }
        public List<long> PatientMedicationInformations { get; set; }
        public List<long> PatientRecords { get; set; }
        [Required]
        public long GenderId { get; set; }
        #endregion Relationship

        #region Columns

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