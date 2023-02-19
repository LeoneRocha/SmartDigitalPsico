using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IUserServices : IGenericServicesEntityBase<User, GetUserVO>
    {
        Task<ServiceResponse<GetUserVO>> Login(string login, string password);
        Task<ServiceResponse<bool>> Logout(string login);
        Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO newEntity);
        Task<ServiceResponse<GetUserVO>> UpdateUser(UpdateUserVO updateEntity);
    }
}