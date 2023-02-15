using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Bussines.Contracts;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using System.Security.Claims;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Data.Contract;
using System.Text;
using System.Collections.Generic;

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
            //_mapper.Map<User>(newEntity);

            entityAdd.PasswordHash = passwordHash;
            entityAdd.PasswordSalt = passwordSalt;
            entityAdd.Enable = true;
            entityAdd.DateCreated = DateTime.Now;
            entityAdd.DateModify = DateTime.Now;
            entityAdd.DateLasAcess = DateTime.Now;

            User entityResponse = await _userRepository.Register(entityAdd);

            response.Data = _mapper.Map<GetUserDto>(entityResponse);
            response.Success = true;
            response.Message = "User registred.";
            return response;
        }

        public Task<ServiceResponse<GetUserDto>> Update(UpdateUserDto updateUser)
        {
            throw new NotImplementedException();
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