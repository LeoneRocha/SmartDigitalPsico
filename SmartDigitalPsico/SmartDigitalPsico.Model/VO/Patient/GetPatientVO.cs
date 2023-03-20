using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Model.VO.Medical;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class GetPatientVO : EntityVOBase, ISupportsHyperMedia
    {
        //MUDAR AS RELACOES PARA OBJETOS 
        #region Relationship
        [Required]
        public GetMedicalVO Medical { get; set; }
        //public List<GetPatientAdditionalInformationVO> PatientAdditionalInformations { get; set; }
        //public List<GetPatientHospitalizationInformationVO> PatientHospitalizationInformations { get; set; }
        //public List<GetPatientMedicationInformationVO> PatientMedicationInformations { get; set; }
        //public List<GetPatientRecordVO> PatientRecords { get; set; }
       
        public Gender Gender  { get; set; }
        #endregion Relationship

        #region Columns

        public DateTime DateOfBirth { get; set; }

   
        public string? Profession { get; set; }

 
        public string? Cpf { get; set; }

     
        public string Rg { get; set; }

   
        public string? Education { get; set; }

    
        public string? PhoneNumber { get; set; }

      
        public string? AddressStreet { get; set; }

      
        public string? AddressNeighborhood { get; set; }

       
        public string? AddressCity { get; set; }

       
        public string? AddressState { get; set; }

 
        public string? AddressCep { get; set; }

      
        public string? EmergencyContactName { get; set; }

     
        public string? EmergencyContactPhoneNumber { get; set; }
       
        public string Email { get; set; }
        #endregion

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}