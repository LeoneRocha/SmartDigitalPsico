using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class UserRepository : GenericRepositoryEntityBase<User>, IUserRepository
    {
        public UserRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async Task<User> FindByLogin(string login)
        {
            User userResult = await _context.Users.FirstOrDefaultAsync(p => p.Login.Equals(login));

            return userResult;
        }

        public async Task<User> Register(User entityAdd)
        {
            _context.Users.Add(entityAdd);
            await _context.SaveChangesAsync();
            return entityAdd;
        }

        public async Task<bool> UserExists(string login)
        {
            if (await _context.Users.AnyAsync(x => x.Login.ToLower().Equals(login.ToLower())))
            {
                return true;
            }
            return false;
        }
    }
}
