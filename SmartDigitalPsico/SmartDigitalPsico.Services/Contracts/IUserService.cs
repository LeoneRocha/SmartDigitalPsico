using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAll();
        Task<ServiceResponse<GetUserDto>> GetById(int id); 
        Task<ServiceResponse<GetUserDto>> UpdateEntity(UpdateUserDto updatedEntity);
        Task<ServiceResponse<GetUserDto>> DeleteEntity(int id);

        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity);
    }
}