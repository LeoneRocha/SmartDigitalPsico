using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;
using System.Data;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class SpecialtyRepository : GenericRepositoryEntityBaseSimple<Specialty>, ISpecialtyRepository, IDisposable
    {
        public SpecialtyRepository(SmartDigitalPsicoDataContext context) : base(context) { }
          
        public async Task<List<Specialty>> FindByIDs(List<long> idsSpecialties)
        {
            return await dataset.Where(p =>  idsSpecialties.Contains(p.Id)).ToListAsync();
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
