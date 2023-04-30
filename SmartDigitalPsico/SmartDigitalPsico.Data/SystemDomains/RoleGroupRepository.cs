using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class RoleGroupRepository : GenericRepositoryEntityBaseSimple<RoleGroup>, IRoleGroupRepository, IDisposable
    {
        public RoleGroupRepository(SmartDigitalPsicoDataContext context) : base(context) { }

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

        public async Task<List<RoleGroup>> FindByIDs(List<long>? roleGroupsIds)
        {
            if (roleGroupsIds == null) { return new List<RoleGroup>(); }

            return await dataset.Where(p => roleGroupsIds.Contains(p.Id)).ToListAsync();
        }
        #endregion
    }
}
