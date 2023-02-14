using System.Threading.Tasks;
using SmartDigitalPsico.WebAPI.Models;

namespace SmartDigitalPsico.WebAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}