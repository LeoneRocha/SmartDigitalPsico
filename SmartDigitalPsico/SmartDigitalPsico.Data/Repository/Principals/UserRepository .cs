using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Data.Repository.Principals
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartDigitalPsicoDataContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(SmartDigitalPsicoDataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<User> Add(User newEntity)
        {
            _context.Users.Add(newEntity);

            await _context.SaveChangesAsync();

            return newEntity;
        }

        public async Task<bool> Delete(int id)
        {
            bool response = false;
            try
            {
                User entityReturn = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (entityReturn != null)
                {
                    _context.Users.Remove(entityReturn);
                    await _context.SaveChangesAsync();

                    response = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            User entityReturn = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return entityReturn;
        }

        public async Task<User> Register(User entityAdd)
        {
            _context.Users.Add(entityAdd);
            await _context.SaveChangesAsync();
            return entityAdd;
        }

        public async Task<User> Update(User updatedEntity)
        {
            bool response = false;
            try
            {
                User entityReturn = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedEntity.Id);

                if (entityReturn != null)
                {
                    entityReturn.Name = updatedEntity.Name;
                    entityReturn.Enable = updatedEntity.Enable;
                    entityReturn.Email = updatedEntity.Email;
                    entityReturn.DateModify = DateTime.Now;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedEntity;
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