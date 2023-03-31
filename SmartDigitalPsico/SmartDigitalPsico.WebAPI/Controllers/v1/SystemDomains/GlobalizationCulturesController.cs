using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Helpers;
using System.Collections.Generic;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    [ApiController]
    [ApiVersion("1")] 
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