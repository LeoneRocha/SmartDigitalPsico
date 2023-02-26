using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.SystemDomains
{
    public interface IApplicationLanguageServices 
        : IGenericServicesEntityBaseSimpleV2<ApplicationLanguage, AddApplicationLanguageVO, UpdateApplicationLanguageVO, GetApplicationLanguageVO>
    {

    }
}