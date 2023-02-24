using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains;

namespace SmartDigitalPsico.Business.Contracts.SystemDomains
{
    public interface IApplicationLanguageBusiness 
        : IGenericBusinessEntityBaseSimpleV2<ApplicationLanguage, AddApplicationConfigSettingVO, UpdateApplicationConfigSettingBusinessVO, GetApplicationConfigSettingBusinessVO>
    {

    }
}