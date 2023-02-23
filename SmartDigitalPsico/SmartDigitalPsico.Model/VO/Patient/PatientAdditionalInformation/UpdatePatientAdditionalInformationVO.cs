using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation
{
    public class UpdatePatientAdditionalInformationVO : AddPatientAdditionalInformationVO , IEntityVO
    {
        [Required]
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}