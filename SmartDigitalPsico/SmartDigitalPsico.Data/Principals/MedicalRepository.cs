//using Microsoft.EntityFrameworkCore;
//using SmartDigitalPsico.Data.Context;
//using SmartDigitalPsico.Data.Contract.Principals;
//using SmartDigitalPsico.Model.Entity.Principals;
//using System.Data;

//namespace SmartDigitalPsico.Data.Repository.Principals
//{
//    public class MedicalRepository : GenericRepositoryEntityBase<Medical>, IUserRepository
//    {
//        public MedicalRepository(SmartDigitalPsicoDataContext context) : base(context) { }

//        public async Task<User> FindByLogin(string login)
//        {
//            User userResult = await _context.Users.FirstOrDefaultAsync(p => p.Login.Equals(login));

//            return userResult;
//        }

//        public async Task<User> Register(User entityAdd)
//        {
//            _context.Users.Add(entityAdd);
//            await _context.SaveChangesAsync();
//            return entityAdd;
//        }

//        public async Task<bool> UserExists(string login)
//        {
//            if (await _context.Users.AnyAsync(x => x.Login.ToLower().Equals(login.ToLower())))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}
