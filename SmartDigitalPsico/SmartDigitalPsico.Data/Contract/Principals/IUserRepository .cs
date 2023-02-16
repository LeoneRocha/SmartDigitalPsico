using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Data.Contract.Principals
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User newEntity);
        Task<User> Update(User updatedEntity);
        Task<bool> Delete(int id);
        Task<User> Register(User entityAdd);

        //Task<ServiceResponse<int>> Register(User user, string password);
        //Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);


    }
}