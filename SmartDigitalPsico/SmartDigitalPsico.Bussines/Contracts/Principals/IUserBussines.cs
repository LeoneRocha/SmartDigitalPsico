using SmartDigitalPsico.Bussines.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Bussines.Contracts.Principals
{
    public interface IUserBussines : IGenericBussinesEntityBase<User, EntityDTOBase> 
    { 
        Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto newEntity);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateEntity);
    }
}