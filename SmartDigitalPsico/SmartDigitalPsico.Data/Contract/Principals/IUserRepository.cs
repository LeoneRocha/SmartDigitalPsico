using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IUserRepository : IRepositoryEntityBase<User>
    {
        Task<User> FindByLogin(string login);
        Task<User> RefreshUserInfo(User user);
        Task<User> Register(User entityAdd);
        Task<bool> UserExists(string login);
    }
}
