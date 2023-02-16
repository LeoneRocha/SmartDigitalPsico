using SmartDigitalPsico.Data.Repository.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Data.Contract.Principals
{
    public interface IUserRepository : IRepositoryEntityBase<User>
    {
        Task<User> Register(User entityAdd);
        Task<bool> UserExists(string username);
    }
}
