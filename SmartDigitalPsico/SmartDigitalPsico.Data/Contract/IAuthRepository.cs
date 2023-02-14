using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity;
using System.Threading.Tasks; 

namespace SmartDigitalPsico.Data.Contract
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Usuario user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}