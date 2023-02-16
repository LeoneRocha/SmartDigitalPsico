using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Data.Contract
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<long>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}