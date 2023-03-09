using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class ApplicationCacheLogRepository : GenericRepositoryEntityBaseSimple<ApplicationCacheLog>, IApplicationCacheLogRepository, IDisposable
    {
        public ApplicationCacheLogRepository(SmartDigitalPsicoDataContext context) : base(context) { }

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

        public async Task<bool> Delete(string cacheKey)
        {
            var result = await dataset.SingleOrDefaultAsync(p => p.CacheKey.ToLower().Equals(cacheKey.ToLower()));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return true;
        }
        #endregion
    }
}
