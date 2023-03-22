using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.User;

namespace SmartDigitalPsico.Business.Contracts.Principals
{
    public interface IUserBusiness : IGenericBusinessEntityBaseV2<User, AddUserVO, UpdateUserVO, GetUserVO>
    {
        Task<ServiceResponse<GetUserAuthenticatedVO>> Login(string username, string password);
        Task<ServiceResponse<bool>> Logout(string username);

        Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO newEntity);
    }
}