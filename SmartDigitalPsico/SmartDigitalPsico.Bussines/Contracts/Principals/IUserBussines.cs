using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IUserBusiness : IGenericBusinessEntityBase<User, GetUserVO>
    {
        Task<ServiceResponse<GetUserVO>> Login(string username, string password);
        Task<ServiceResponse<bool>> Logout(string username);
        Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO newEntity);
        Task<ServiceResponse<GetUserVO>> UpdateUser(UpdateUserVO updateEntity);
    }
}