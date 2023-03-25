using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class PatientFileRepository : GenericRepositoryEntityBaseSimple<PatientFile>, IPatientFileRepository
    {
        public PatientFileRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async override Task<PatientFile> FindByID(long id)
        {
            return await dataset
                .Include(e => e.Patient)
                .Include(e => e.Patient.Medical)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async override Task<List<PatientFile>> FindAll()
        {
            return await dataset
                .Include(e => e.Patient)
                .ToListAsync();
        }

    }
}
