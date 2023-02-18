using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class SpecialtyRepository : GenericRepositoryEntityBaseSimple<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(SmartDigitalPsicoDataContext context) : base(context) { }
    }
}
