using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Domains.Security;

namespace SmartDigitalPsico.Business.Principals
{
    public class UserBusiness : GenericBusinessEntityBase<User, IUserRepository, GetUserVO>, IUserBusiness

    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        IConfiguration _configuration;
        public UserBusiness(IMapper mapper, IUserRepository entityRepository, IConfiguration configuration)
            : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _userRepository = entityRepository;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<GetUserVO>> Login(string login, string password)
        {
            var response = new ServiceResponse<GetUserVO>();

            var user = await _userRepository.FindByLogin(login);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!SecurityHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = createToken(user);
                response.Message = "User Logged.";
            }

            return response;
        }

        public async Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO userRegisterVO)
        {
            ServiceResponse<GetUserVO> response = new ServiceResponse<GetUserVO>();

            if (await UserExists(userRegisterVO.Login))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }
            SecurityHelper.CreatePasswordHash(userRegisterVO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User entityAdd = _mapper.Map<User>(userRegisterVO);

            entityAdd.Role = "Pendente";
            entityAdd.Admin = false;
            entityAdd.PasswordHash = passwordHash;
            entityAdd.PasswordSalt = passwordSalt;
            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;
             
            User entityResponse = await _userRepository.Register(entityAdd);

            response.Data = _mapper.Map<GetUserVO>(entityResponse);
            response.Success = true;
            response.Message = "User registred.";
            return response;
        }

        public async Task<ServiceResponse<GetUserVO>> UpdateUser(UpdateUserVO updateUser)
        {
            ServiceResponse<GetUserVO> response = new ServiceResponse<GetUserVO>();
            User entityUpdate = await _userRepository.FindByID(updateUser.Id);

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
            response.Data = _mapper.Map<GetUserVO>(entityResponse);

            if (response.Success)
                response.Message = "User Updated.";

            return response;
        }

        public async Task<bool> UserExists(string login)
        {
            bool response = await _userRepository.UserExists(login);

            return response;
        }

        public async Task<ServiceResponse<bool>> Logout(string login)
        {
            var response = new ServiceResponse<bool>();
            bool user = await _userRepository.UserExists(login);
            if (!user)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else
            {
                response.Success = false;
                response.Message = "User logout.";
            }
            return response;
        }



        private GetUserVO createToken(User user)
        {
            GetUserVO response = _mapper.Map<GetUserVO>(user);
            var key = _configuration.GetSection("AppSettings:Token").Value;
            response.TokenAuth = SecurityHelper.CreateToken(new SecurityVO() { Name = user.Name, Role = user.Role, SecurityKeyConfig = key });
            return response;
        }
    }
}