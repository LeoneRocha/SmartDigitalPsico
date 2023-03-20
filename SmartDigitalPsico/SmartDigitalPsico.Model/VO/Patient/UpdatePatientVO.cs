using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Model.VO.Contracts;

namespace SmartDigitalPsico.Model.VO.Patient
{
    public class UpdatePatientVO : AddPatientVO, IEntityVO
    {
        public long Id { get; set; }
        public bool Enable { get; set; }
    }
}