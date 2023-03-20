using SmartDigitalPsico.Model.VO.Contracts;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public class UpdateMedicalVO : AddMedicalVO, IEntityVO
    {
        public long Id { get; set; }
    }
}