using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class UpdatePatientVO : AddPatientVO
    {
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}