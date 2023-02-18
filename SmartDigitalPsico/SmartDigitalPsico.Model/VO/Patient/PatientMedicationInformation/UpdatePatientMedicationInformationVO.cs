using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation
{
    public class UpdatePatientMedicationInformationVO : AddPatientMedicationInformationVO
    {
        [Required]
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}