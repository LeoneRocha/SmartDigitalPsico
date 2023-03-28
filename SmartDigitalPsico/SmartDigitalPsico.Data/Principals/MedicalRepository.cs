using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals; 
using SmartDigitalPsico.Repository.Generic;
using System.Data;

namespace SmartDigitalPsico.Repository.Principals
{
    public class MedicalRepository : GenericRepositoryEntityBase<Medical>, IMedicalRepository
    {
        public MedicalRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async Task<bool> Exists(string accreditation)
        {
            return await dataset.AnyAsync(x => x.Accreditation.ToLower().Equals(accreditation.ToLower()));
        }
        public async override Task<Medical> FindByID(long id)
        {
            return await dataset
                .Include(e => e.Office)
                .Include(e => e.Specialties)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async override Task<List<Medical>> FindAll()
        {
            return await dataset
                .Include(e => e.Office)
                .Include(e => e.Specialties)
                .ToListAsync();
        }

        public async Task<Medical> FindByEmail(string value)
        {
            Medical entityResult = await dataset.FirstOrDefaultAsync(p => p.Email.ToLower().Trim().Equals(value.ToLower().Trim()));

            return entityResult;
        } 
        public async Task<Medical> FindByAccreditation(string value)
        {
            Medical entityResult = await dataset.FirstOrDefaultAsync(p => p.Accreditation.ToLower().Trim().Equals(value.ToLower().Trim()));

            return entityResult;
        }  
    }
}
