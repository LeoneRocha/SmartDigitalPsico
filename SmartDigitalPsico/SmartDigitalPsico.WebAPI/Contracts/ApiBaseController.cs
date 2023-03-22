using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.WebAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

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