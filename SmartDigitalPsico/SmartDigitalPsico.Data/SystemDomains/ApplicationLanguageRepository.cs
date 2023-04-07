using Localization.SqlLocalizer.DbStringLocalizer;
using Microsoft.Extensions.Localization;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class ApplicationLanguageRepository : GenericRepositoryEntityBaseSimple<ApplicationLanguage>, IApplicationLanguageRepository, IDisposable
    {
        private LocalizationModelContext _localizationModelContext;
        private IStringExtendedLocalizerFactory _stringLocalizerFactory;


        public ApplicationLanguageRepository(SmartDigitalPsicoDataContext context,
              LocalizationModelContext localizationModelContext, IStringExtendedLocalizerFactory stringLocalizerFactory)
            : base(context)
        {
            _localizationModelContext = localizationModelContext;
            _stringLocalizerFactory = stringLocalizerFactory;
        }
        public override async Task<ApplicationLanguage> Create(ApplicationLanguage item)
        {
            try
            {
                _localizationModelContext.Add(new LocalizationRecord
                {
                    Key = $"{item.LanguageKey}",
                    Text = item.LanguageValue,
                    LocalizationCulture = item.Language,
                    ResourceKey = item.ResourceKey //typeof(ApplicationLanguage).FullName
                });

                await _localizationModelContext.SaveChangesAsync();
                _stringLocalizerFactory.ResetCache();

            }
            catch (Exception)
            {

                throw;
            }


            return await base.Create(item);
        }

        public override async Task<ApplicationLanguage> Update(ApplicationLanguage item)
        {
            try
            {
                var localRegister = _localizationModelContext.LocalizationRecords
                    .Single(lc => lc.ResourceKey == item.ResourceKey && lc.Key == item.LanguageKey);

                localRegister.Text = item.LanguageValue;
                localRegister.LocalizationCulture = item.Language;

                _localizationModelContext.Update(localRegister);

                await _localizationModelContext.SaveChangesAsync(true);

                _stringLocalizerFactory.ResetCache();

            }
            catch (Exception)
            {

                throw;
            }
            return await base.Update(item);
        }

        public override async Task<bool> Delete(long id)
        {

            try
            { 
                ApplicationLanguage item = await base.FindByID(id);
                var localRegister = _localizationModelContext.LocalizationRecords
                .Single(lc => lc.ResourceKey == item.ResourceKey && lc.Key == item.LanguageKey);
                 
                _localizationModelContext.Remove(localRegister);

                await _localizationModelContext.SaveChangesAsync(true);


                _stringLocalizerFactory.ResetCache();

            }
            catch (Exception)
            {

                throw;
            }

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
