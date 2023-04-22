using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class PatientAdditionalInformationRepository : GenericRepositoryEntityBaseSimple<PatientAdditionalInformation>, IPatientAdditionalInformationRepository
    {
        public PatientAdditionalInformationRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async Task<List<PatientAdditionalInformation>> FindAllByPatient(long patientId)
        {
            return await dataset
                .Include(e => e.Patient)
                .Include(e => e.Patient.Medical)
                .Include(e => e.Patient.Medical.User)
                .Include(e => e.CreatedUser)
                .Where(x => x.Patient.Id == patientId).ToListAsync();
        }

        public async override Task<PatientAdditionalInformation> FindByID(long id)
        {
            return await dataset
                .Include(e => e.Patient)
                .Include(e => e.Patient.Medical)
                .Include(e => e.Patient.Medical.User)
                .Include(e => e.CreatedUser)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async override Task<List<PatientAdditionalInformation>> FindAll()
        {
            return await dataset
                .Include(e => e.Patient)
                .ToListAsync();
        }

    }
}
