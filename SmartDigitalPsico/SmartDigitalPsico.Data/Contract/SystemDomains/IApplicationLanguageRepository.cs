using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.SystemDomains
{
    public interface IApplicationLanguageRepository : IRepositoryEntityBaseSimple<ApplicationLanguage>
    {
        Task<ApplicationLanguage> Find(string language, string languageKey, string resourceKey = "SharedResource");

    }
}
