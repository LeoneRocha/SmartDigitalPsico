using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Model.VO.Utils;
using SmartDigitalPsico.Repository.Contract.Principals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartDigitalPsico.Business.Principals
{
    public class UserBusiness : GenericBusinessEntityBase<User, AddUserVO, UpdateUserVO, GetUserVO, IUserRepository>, IUserBusiness

    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        IConfiguration _configuration;
        ITokenConfiguration _configurationToken;
        private readonly ITokenService _tokenService;
        AuthConfigurationVO _configurationAuth; 
        public UserBusiness(IMapper mapper, IUserRepository entityRepository, IConfiguration configuration
            , ITokenConfiguration configurationToken, ITokenService tokenService, IOptions<AuthConfigurationVO> configurationAuth, IValidator<User> entityValidator)
            : base(mapper, entityRepository, entityValidator)
        {
            _mapper = mapper;
            _userRepository = entityRepository;
            _configuration = configuration;
            _configurationToken = configurationToken;
            _tokenService = tokenService;
            _configurationAuth = configurationAuth.Value;
        }

        public async Task<ServiceResponse<GetUserAuthenticatedVO>> Login(string login, string password)
        {
            var response = new ServiceResponse<GetUserAuthenticatedVO>();

            var user = await _userRepository.FindByLogin(login);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }
            else if (!SecurityHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
                return response;
            }

            if (_configurationAuth.TypeApiCredential == Domains.Enuns.ETypeApiCredential.Jwt)
            {
                response.Data = await executeLoginJwt(user);
            }
            response.Success = true;
            response.Message = "User Logged.";
            return response;
        }

        public async Task<ServiceResponse<GetUserVO>> Register(UserRegisterVO userRegisterVO)
        {
            ServiceResponse<GetUserVO> response = new ServiceResponse<GetUserVO>();
            try
            {
                SecurityHelper.CreatePasswordHash(userRegisterVO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                User entityAdd = _mapper.Map<User>(userRegisterVO);

                entityAdd.PasswordHash = passwordHash;
                entityAdd.PasswordSalt = passwordSalt;
                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;
                entityAdd.Role = "Pendente";
                entityAdd.Admin = false;

                response = await base.Validate(entityAdd);

                if (response.Success)
                {
                    User entityResponse = await _userRepository.Register(entityAdd);
                    response.Data = _mapper.Map<GetUserVO>(entityResponse);
                    response.Message = "User registred.";
                }
            }
            catch (Exception ex)
            {
                //TODO: GENARATE LOGS
                throw ex;
            } 
            return response;
        }

        public override async Task<ServiceResponse<GetUserVO>> Update(UpdateUserVO updateUser)
        {
            ServiceResponse<GetUserVO> response = new ServiceResponse<GetUserVO>();

            try
            { 
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

                User entityResponse = await _userRepository.Update(entityUpdate);
                response.Success = true;
                response.Data = _mapper.Map<GetUserVO>(entityResponse);

                if (response.Success)
                    response.Message = "User Updated.";
            }
            catch (Exception)
            {

                throw;
            }

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

        private async Task<GetUserAuthenticatedVO> executeLoginJwt(User user)
        {
            TokenVO token = await validateCredentials(user);
            GetUserAuthenticatedVO response = _mapper.Map<GetUserAuthenticatedVO>(user);
            response.TokenAuth = token;
            return response;
        }

        private async Task<TokenVO> validateCredentials(User user)
        {
            if (user == null) return new TokenVO();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configurationToken.DaysToExpiry);

            await _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configurationToken.Minutes);
            return new TokenVO(true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public async Task<TokenVO> validateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal?.Identity?.Name;

            long idUser = 0;

            long.TryParse(username, out idUser);

            var user = await _userRepository.FindByID(idUser);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configurationToken.Minutes);
            return new TokenVO(
            true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        } 
    }
}