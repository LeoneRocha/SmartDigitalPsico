using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation
{
    public class UpdatePatientAdditionalInformationVO : EntityVOBase
    { 
        public string FollowUp_Psychiatric { get; set; }

        public string FollowUp_Neurological { get; set; }

    }
}