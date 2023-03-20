using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class PatientNotificationMessageRepository : GenericRepositoryEntityBaseSimple<PatientNotificationMessage>, IPatientNotificationMessageRepository
    {
        public PatientNotificationMessageRepository(SmartDigitalPsicoDataContext context) : base(context) { }
         
        public async Task<List<PatientNotificationMessage>> FindAllByPatient(long patientId)
        {
            return await dataset.Where(x => x.Patient.Id == patientId).ToListAsync();
        }


        public async override Task<PatientNotificationMessage> FindByID(long id)
        {
            return await dataset
                .Include(e => e.Patient)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async override Task<List<PatientNotificationMessage>> FindAll()
        {
            return await dataset
                .Include(e => e.Patient)
                .ToListAsync();
        }

    }
}
