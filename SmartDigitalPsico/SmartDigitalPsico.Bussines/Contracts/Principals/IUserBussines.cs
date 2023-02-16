using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Bussines.Contracts.Principals
{
    public interface IUserBussines
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAll();
        Task<ServiceResponse<GetUserDto>> GetById(int id); 
        Task<ServiceResponse<GetUserDto>> Update(UpdateUserDto updatedEntity);
        Task<ServiceResponse<GetUserDto>> Delete(int id);
        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity);
    }
}