using AutoMapper;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Bussines.Generic;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class UserService : GenericServicesEntityBase<User, IUserBussines, EntityDTOBase>, IUserService

    { 
        private readonly IUserBussines _userBussines;

        public UserService(IMapper mapper, IUserBussines entityBussines)
            : base(mapper, entityBussines)
        {
            _userBussines = entityBussines;
        }

        public async Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.Register(newEntity);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateEntity)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            serviceResponse = await _userBussines.UpdateUser(updateEntity);

            return serviceResponse;
        }
    }
}