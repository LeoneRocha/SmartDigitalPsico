using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class MedicalFileRepository : GenericRepositoryEntityBaseSimple<MedicalFile>, IMedicalFileRepository
    {
        public MedicalFileRepository(SmartDigitalPsicoDataContext context) : base(context) { } 
        
    }
}
