using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Data.Contract.SystemDomains;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Data.Repository.SystemDomains
{
    public class GenderRepository : GenericRepositoryEntityBaseSimple<Gender>, IGenderRepository
    {
        public GenderRepository(SmartDigitalPsicoDataContext context) : base(context) { } 
    }
}
