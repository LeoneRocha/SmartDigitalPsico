using AutoMapper;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Bussines.Principals
{
    public class UserBussines : IUserBussines
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserBussines(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }

        public async Task<ServiceResponse<GetUserDto>> Delete(int id)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User entityResponse = await _userRepository.GetById(id);
            bool exists = await UserExists(entityResponse.Name);
            if (!exists)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }
            response.Success = await _userRepository.Delete(id);

            if (response.Success)
                response.Message = "User deleted.";

            return response;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAll()
        {
            ServiceResponse<List<GetUserDto>> response = new ServiceResponse<List<GetUserDto>>();
            List<User> entityResponse = await _userRepository.GetAll();

            response.Data = entityResponse.Select(c => _mapper.Map<GetUserDto>(c)).ToList();

            response.Success = true;
            response.Message = "User exist.";
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User entityResponse = await _userRepository.GetById(id);

            response.Data = _mapper.Map<GetUserDto>(entityResponse);
            response.Success = true;
            response.Message = "User exist.";
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> Register(UserRegisterDto userRegisterDto)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();

            if (await UserExists(userRegisterDto.Username))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            } 
            createPasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
             
            User entityAdd = _mapper.Map<User>(userRegisterDto);

            entityAdd.Name = userRegisterDto.Username;  

            entityAdd.PasswordHash = passwordHash;
            entityAdd.PasswordSalt = passwordSalt;
            entityAdd.Enable = true;
            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            User entityResponse = await _userRepository.Register(entityAdd);

            response.Data = _mapper.Map<GetUserDto>(entityResponse);
            response.Success = true;
            response.Message = "User registred.";
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> Update(UpdateUserDto updateUser)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User entityUpdate = await _userRepository.GetById(updateUser.Id);
            bool exists = await UserExists(entityUpdate.Name);
            if (!exists)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }  
            entityUpdate.Name = updateUser.Name; 
            entityUpdate.Enable = updateUser.Enable;
            entityUpdate.Email = updateUser.Email;
            entityUpdate.ModifyDate = DateTime.Now;
             
            User entityResponse = await _userRepository.Update(entityUpdate);
            response.Success = true;
            response.Data = _mapper.Map<GetUserDto>(entityResponse); 

            if (response.Success)
                response.Message = "User Updated.";

            return response;
        }
        private async Task<bool> UserExists(string username)
        {
            bool response = await _userRepository.UserExists(username);

            return response;
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}