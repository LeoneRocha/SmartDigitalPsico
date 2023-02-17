using SmartDigitalPsico.Bussines.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IUserService : IGenericServicesEntityBase<User, EntityDTOBase>
    {
        Task<ServiceResponse<GetUserDto>> Login(string login, string password);
        Task<ServiceResponse<bool>> Logout(string login);
        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateEntity);
    }
}