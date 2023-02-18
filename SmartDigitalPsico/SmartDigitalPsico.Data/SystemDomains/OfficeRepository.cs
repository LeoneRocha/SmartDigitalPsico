using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class OfficeRepository : GenericRepositoryEntityBaseSimple<Office>, IOfficeRepository
    {
        public OfficeRepository(SmartDigitalPsicoDataContext context) : base(context) { }
    }
}
