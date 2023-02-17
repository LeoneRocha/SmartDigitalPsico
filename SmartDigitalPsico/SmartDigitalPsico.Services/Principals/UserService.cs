using AutoMapper;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class UserService : GenericServicesEntityBase<User, IUserBusiness, GetUserVO>, IUserService

    { 
        private readonly IUserBusiness _userBusiness;

        public UserService(IMapper mapper, IUserBusiness entityBusiness)
            : base(mapper, entityBusiness)
        {
            _userBusiness = entityBusiness;
        }

        public async override Task<ServiceResponse<bool>> Delete(long id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _userBusiness.EnableOrDisable(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserVO>> Login(string username, string password)
        {
            var serviceResponse = new ServiceResponse<GetUserVO>();

            serviceResponse = await _userBusiness.Login(username, password);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Logout(string username)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _userBusiness.Logout(username);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO newEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserVO>();

            serviceResponse = await _userBusiness.Register(newEntity);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserVO>> UpdateUser(UpdateUserVO updateEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserVO>();

            serviceResponse = await _userBusiness.UpdateUser(updateEntity);

            return serviceResponse;
        }
    }
}