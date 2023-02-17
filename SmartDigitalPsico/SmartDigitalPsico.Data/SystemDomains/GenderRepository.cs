using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.SystemDomains
{
    public class GenderRepository : GenericRepositoryEntityBaseSimple<Gender>, IGenderRepository
    {
        public GenderRepository(SmartDigitalPsicoDataContext context) : base(context) { }
    }
}
