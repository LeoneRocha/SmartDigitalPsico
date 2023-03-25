using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation
{
    public class UpdatePatientMedicationInformationVO : EntityVOBase
    {

        #region Columns 
         
        public string Description { get; set; }
         
        public DateTime StartDate { get; set; }
         
        public DateTime? EndDate { get; set; }
         
        public string? Dosage { get; set; }
         
        public string? Posology { get; set; }
         
        public string? MainDrug { get; set; }
         
        #endregion Columns 


    }
}