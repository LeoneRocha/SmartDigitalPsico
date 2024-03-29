using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Services.Generic.Contracts;

namespace SmartDigitalPsico.Services.Contracts.Principals
{
    public interface IUserServices : IGenericServicesEntityBase<User, AddUserVO, UpdateUserVO, GetUserVO>
    {
        Task<ServiceResponse<GetUserAuthenticatedVO>> Login(string login, string password);
        Task<ServiceResponse<bool>> Logout(string login);
        Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO newEntity);

        Task<ServiceResponse<GetUserVO>> UpdateProfile(UpdateUserProfileVO updateEntity);
    }
}