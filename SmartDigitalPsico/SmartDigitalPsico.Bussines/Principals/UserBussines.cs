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
            else if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
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

            if (await UserExists(userRegisterVO.Name))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }
            createPasswordHash(userRegisterVO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User entityAdd = _mapper.Map<User>(userRegisterVO);

            entityAdd.Role = "ADMIN";
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

        private GetUserVO createToken(User user)
        {
            GetUserVO response = _mapper.Map<GetUserVO>(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokendDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokendDescriptor);
            response.TokenAuth = tokenHandler.WriteToken(token);
            return response;
        }
    }
}