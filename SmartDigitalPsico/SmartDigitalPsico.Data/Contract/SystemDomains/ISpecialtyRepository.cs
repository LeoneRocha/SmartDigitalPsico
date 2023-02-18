using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.SystemDomains
{
    public interface ISpecialtyRepository : IRepositoryEntityBaseSimple<Specialty>
    {
        Task<List<Specialty>> FindByIDs(List<long> idsSpecialties);
    }
}
