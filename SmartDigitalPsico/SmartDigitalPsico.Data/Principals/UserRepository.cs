using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class UserRepository : GenericRepositoryEntityBase<User>, IUserRepository, IDisposable
    {
        public UserRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async Task<User> FindByLogin(string login)
        {
            User userResult = await dataset.FirstOrDefaultAsync(p => p.Login.Equals(login));

            return userResult;
        } 
        public async Task<User> Register(User entityAdd)
        {
            dataset.Add(entityAdd);
            await _context.SaveChangesAsync();
            return entityAdd;
        }

        public async Task<bool> UserExists(string login)
        {
            if (await dataset.AnyAsync(x => x.Login.ToLower().Equals(login.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async override Task<List<User>> FindAll()
        {
            return await dataset.Include(e=> e.RoleGroups).ToListAsync();
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
