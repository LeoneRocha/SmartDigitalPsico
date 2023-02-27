using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IMedicalFileBusiness : IGenericBusinessEntityBaseSimpleV2<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO>
    {
       
    }
}