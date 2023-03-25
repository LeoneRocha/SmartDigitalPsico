using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IMedicalRepository : IRepositoryEntityBase<Medical>
    {
        Task<bool> Exists(string accreditation);
        Task<Medical> FindByAccreditation(string accreditation);
        Task<Medical> FindByEmail(string email);
    }
}
