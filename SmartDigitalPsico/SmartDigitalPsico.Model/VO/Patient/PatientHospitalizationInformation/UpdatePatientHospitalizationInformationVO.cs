using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation
{
    public class UpdatePatientHospitalizationInformationVO : AddPatientHospitalizationInformationVO , IEntityVO
    {
        [Required]
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}