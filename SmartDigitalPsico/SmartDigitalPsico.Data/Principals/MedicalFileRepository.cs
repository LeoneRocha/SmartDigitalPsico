using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class MedicalFileRepository : GenericRepositoryEntityBaseSimple<MedicalFile>, IMedicalFileRepository
    {
        public MedicalFileRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async override Task<List<MedicalFile>> FindAll()
        {
            return await dataset.Include(e => e.Medical).ToListAsync();
        }

        public async Task<List<MedicalFile>> FindAllByMedical(long medicalId)
        {
            return await dataset.Where(e => e.MedicalId == medicalId).Include(e => e.Medical).ToListAsync();
        }
    }
}
