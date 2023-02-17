using AutoMapper;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class UserService : GenericServicesEntityBase<User, IUserBusiness, GetUserDto>, IUserService

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

        public async Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBusiness.Login(username, password);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Logout(string username)
        {
            var serviceResponse = new ServiceResponse<bool>();

            serviceResponse = await _userBusiness.Logout(username);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBusiness.Register(newEntity);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBusiness.UpdateUser(updateEntity);

            return serviceResponse;
        }
    }
}