using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.WebAPI.Helper;
using System.Globalization;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    public class ApiBaseController : ControllerBase
    {
        protected AuthConfigurationVO _configurationAuth;

        public ApiBaseController(IOptions<AuthConfigurationVO> configurationAuth)
        {
            _configurationAuth = configurationAuth.Value;
        }
       
        protected void SetCurrentCulture()
        {
            var requestedCulture = base.Request.Headers["X-Culture"].ToString();

            if (!string.IsNullOrWhiteSpace(requestedCulture))
            {
                var cultureInfo = new CultureInfo(requestedCulture);
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            }   
        }

        protected long GetUserIdCurrent()
        {
            SetCurrentCulture();   
            long idUser = SecurityHelperApi.GetUserIdApi(User, _configurationAuth.TypeApiCredential);
            return idUser;
            //_entityService.SetUserId();
        }
    }
}