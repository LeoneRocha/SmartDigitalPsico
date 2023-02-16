using SmartDigitalPsico.Model.Entity.Principals;

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
         
        Task<bool> UserExists(string username); 
    }
}