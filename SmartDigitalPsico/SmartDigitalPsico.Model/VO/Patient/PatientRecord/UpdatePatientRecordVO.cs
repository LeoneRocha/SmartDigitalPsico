using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Model.VO.Patient.PatientRecord
{
    public class UpdatePatientRecordVO : AddPatientRecordVO
    {
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}