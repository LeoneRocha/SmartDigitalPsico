using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Data.Repository.Principals
{
    public class UserRepository : GenericRepositoryEntityBase<User>, IUserRepository
    {
        public UserRepository(SmartDigitalPsicoDataContext context) : base(context) { }
         
        public async Task<User> Register(User entityAdd)
        {
            _context.Users.Add(entityAdd);
            await _context.SaveChangesAsync();
            return entityAdd;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Name.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }
    }
}
