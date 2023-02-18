using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class PatientHospitalizationInformationRepository : GenericRepositoryEntityBaseSimple<PatientHospitalizationInformation>, IPatientHospitalizationInformationRepository
    {
        public PatientHospitalizationInformationRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        public async Task<List<PatientHospitalizationInformation>> FindAllByPatient(long patientId)
        {
            return await dataset.Where(x => x.Patient.Id == patientId).ToListAsync();
        }

    }
}
