using SmartDigitalPsico.Domains.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Domains.Hypermedia;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class GetPatientVO : EntityVOBase, ISupportsHyperMedia
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