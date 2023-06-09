using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class MedicalCalendarRepository : GenericRepositoryEntityBaseSimple<MedicalCalendar>, IMedicalCalendarRepository
    {
        public MedicalCalendarRepository(SmartDigitalPsicoDataContext context) : base(context) { }
         
    }
}
