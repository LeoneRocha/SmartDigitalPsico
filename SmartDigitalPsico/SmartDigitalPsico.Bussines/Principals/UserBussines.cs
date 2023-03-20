using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.VO.Utils;
using SmartDigitalPsico.Repository.Contract.Principals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartDigitalPsico.Business.Principals
{
    public class UserBusiness : GenericBusinessEntityBase<User, IUserRepository, GetUserVO>, IUserBusiness

    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        IConfiguration _configuration;
        ITokenConfiguration _configurationToken;
        private readonly ITokenService _tokenService;

        public UserBusiness(IMapper mapper, IUserRepository entityRepository, IConfiguration configuration
            , ITokenConfiguration configurationToken, ITokenService tokenService)
            : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _userRepository = entityRepository;
            _configuration = configuration;
            _configurationToken = configurationToken;
            _tokenService = tokenService;
        }

        public async Task<ServiceResponse<GetUserAuthenticatedVO>> Login(string login, string password)
        {
            var response = new ServiceResponse<GetUserAuthenticatedVO>();

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



        private GetUserAuthenticatedVO createToken(User user)
        { 
            var key = _configuration.GetSection("AppSettings:Token").Value;
            SecurityVO securityVO = new SecurityVO() { Name = user.Name, Role = user.Role, SecurityKeyConfig = key };

            TokenVO token = ValidateCredentials(user);
            GetUserAuthenticatedVO response = _mapper.Map<GetUserAuthenticatedVO>(user);
            response.TokenAuth = token;

            return response;
        }

        private TokenVO ValidateCredentials(User user)
        {
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name)
            }; 

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configurationToken.DaysToExpiry);


            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configurationToken.Minutes);
            return new TokenVO(true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        //public TokenVO ValidateCredentials(TokenVO token)
        //{
        //    var accessToken = token.AccessToken;
        //    var refreshToken = token.RefreshToken;

        //    var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

        //    var username = principal.Identity.Name;

        //    var user = _repository.ValidateCredentials(username);

        //    if (user == null ||
        //        user.RefreshToken != refreshToken ||
        //        user.RefreshTokenExpiryTime <= DateTime.Now) return null;

        //    accessToken = _tokenService.GenerateAccessToken(principal.Claims);
        //    refreshToken = _tokenService.GenerateRefreshToken();

        //    user.RefreshToken = refreshToken;

        //    _repository.RefreshUserInfo(user);

        //    DateTime createDate = DateTime.Now;
        //    DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
        //    return new TokenVO(
        //    true,
        //        createDate.ToString(DATE_FORMAT),
        //        expirationDate.ToString(DATE_FORMAT),
        //        accessToken,
        //        refreshToken
        //        );
        //}
    }
}