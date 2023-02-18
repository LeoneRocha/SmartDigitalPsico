using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts.Interface;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Model.VO.Medical
{
    public abstract class BasePatientVO : EntityVOBase, IEntityVOUserLog
    {
        public long IdUserAction { get; set; }

        #region Relationship

        public long MedicalId { get; set; }
        public long GenderId { get; set; }

        #endregion Relationship






    }
}