
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class ApplicationLanguageRepository : GenericRepositoryEntityBaseSimple<ApplicationLanguage>, IApplicationLanguageRepository, IDisposable
    {
        //private LocalizationModelContext _localizationModelContext;
        //private IStringExtendedLocalizerFactory _stringLocalizerFactory;


        public ApplicationLanguageRepository(SmartDigitalPsicoDataContext context 
           //   LocalizationModelContext localizationModelContext, IStringExtendedLocalizerFactory stringLocalizerFactory
            )
            : base(context)
        {
            //_localizationModelContext = localizationModelContext;
            //_stringLocalizerFactory = stringLocalizerFactory;
        }
        public override async Task<ApplicationLanguage> Create(ApplicationLanguage item)
        {
            //try
            //{
            //    var newRessource = new LocalizationRecord
            //    {
            //        Key = getKeyLocalizationRecord(item),
            //        Text = item.LanguageValue,
            //        LocalizationCulture = item.Language,
            //        ResourceKey = item.ResourceKey //typeof(ApplicationLanguage).FullName
            //    };

            //    _localizationModelContext.Add(newRessource);

            //    await _localizationModelContext.SaveChangesAsync();
            //    _stringLocalizerFactory.ResetCache();

            //}
            //catch (Exception)
            //{
            //}


            return await base.Create(item);
        }

        private string getKeyLocalizationRecord(ApplicationLanguage item)
        {
            return CultureDateTimeHelper.GetKeyLocalizationRecordFormat(item.LanguageKey, item.Language);
        }

        public override async Task<ApplicationLanguage> Update(ApplicationLanguage item)
        {
            //try
            //{
            //    var localRegister = _localizationModelContext.LocalizationRecords
            //        .Single(lc => lc.ResourceKey == item.ResourceKey && lc.Key == getKeyLocalizationRecord(item));

            //    localRegister.Text = item.LanguageValue;
            //    localRegister.LocalizationCulture = item.Language;

            //    _localizationModelContext.Update(localRegister);

            //    await _localizationModelContext.SaveChangesAsync(true);

            //    _stringLocalizerFactory.ResetCache();

            //}
            //catch (Exception)
            //{
            //}
            return await base.Update(item);
        }

        public async Task<ApplicationLanguage> Find(string language, string languageKey, string resourceKey = "SharedResource")
        {
            return await dataset.SingleAsync(p =>
            p.ResourceKey.ToUpper().Trim().Equals(resourceKey.ToUpper().Trim())
            && p.LanguageKey.ToUpper().Trim().Equals(languageKey.ToUpper().Trim())
            && p.Language.ToUpper().Trim().Equals(language.ToUpper().Trim())
            );
        } 

        public override async Task<bool> Delete(long id)
        {

            //try
            //{
            //    ApplicationLanguage item = await base.FindByID(id);
            //    var localRegister = _localizationModelContext.LocalizationRecords
            //    .Single(lc => lc.ResourceKey == item.ResourceKey && lc.Key == getKeyLocalizationRecord(item));

            //    _localizationModelContext.Remove(localRegister);

            //    await _localizationModelContext.SaveChangesAsync(true);


            //    _stringLocalizerFactory.ResetCache();

            //}
            //catch (Exception)
            //{

            //}

            return await base.Delete(id);
        }

        #region DISPOSE
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                //if (disposing)
                //{ 
                //}
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
