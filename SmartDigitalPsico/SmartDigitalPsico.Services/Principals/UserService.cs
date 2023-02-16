using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Security.Claims;

namespace SmartDigitalPsico.Services.Principals
{
    public class UserService : IUserService
    {
        private readonly IUserBussines _userBussines;

        public UserService(IUserBussines userBussines)
        {
            _userBussines = userBussines;
        } 
        public async Task<ServiceResponse<GetUserDto>> DeleteEntity(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.Delete(id);

            return serviceResponse;
        } 
        public async Task<ServiceResponse<List<GetUserDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            serviceResponse = await _userBussines.GetAll();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.GetById(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.Register(newEntity);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateEntity(UpdateUserDto updatedEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.Update(updatedEntity);

            return serviceResponse;
        }
    }
}