using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GlobalizationCulturesController : ControllerBase
    {  
        public GlobalizationCulturesController( )
        { 
        }

        [HttpGet("GetCultures")] 
        public ActionResult<List<CultureDisplay>> Get()
        { 
            return Ok(CultureDateTimeHelper.GetCultures());
        }
    }
}