using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IUserBusiness : IGenericBusinessEntityBase<User, GetUserDto>
    {
        Task<ServiceResponse<GetUserDto>> Login(string username, string password);
        Task<ServiceResponse<bool>> Logout(string username);
        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateEntity);
    }
}