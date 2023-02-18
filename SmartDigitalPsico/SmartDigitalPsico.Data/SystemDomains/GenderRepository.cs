using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class GenderRepository : GenericRepositoryEntityBaseSimple<Gender>, IGenderRepository, IDisposable
    {
        public GenderRepository(SmartDigitalPsicoDataContext context) : base(context) { }

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
