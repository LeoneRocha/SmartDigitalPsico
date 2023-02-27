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
        
    }
}
