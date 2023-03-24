using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.WebAPI.Helper;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    public class ApiBaseController : ControllerBase
    {
        protected AuthConfigurationVO _configurationAuth;

        public ApiBaseController(IOptions<AuthConfigurationVO> configurationAuth)
        {
            _configurationAuth = configurationAuth.Value;
        }

        protected long GetUserIdCurrent()
        {
            long idUser = SecurityHelperApi.GetUserIdApi(User, _configurationAuth.TypeApiCredential);
            return idUser;
            //_entityService.SetUserId();
        }
    }
}