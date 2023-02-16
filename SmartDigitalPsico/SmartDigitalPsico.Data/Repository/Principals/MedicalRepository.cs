using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Data.Repository.Principals
{
    public class MedicalRepository : IMedicalRepository
    {
        private readonly SmartDigitalPsicoDataContext _context;
        private readonly IConfiguration _configuration;
        public MedicalRepository(SmartDigitalPsicoDataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<Medical> Add(Medical newEntity)
        {
            _context.Medicals.Add(newEntity);

            await _context.SaveChangesAsync();

            return newEntity;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medical>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Medical> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Medical> Update(Medical updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}