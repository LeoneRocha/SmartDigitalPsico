using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Helpers;
using System.Collections.Generic;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GlobalizationTimeZonesController : ControllerBase
    {  
        public GlobalizationTimeZonesController( )
        { 
        } 
        //[AllowAnonymous]
        [HttpGet("GetTimeZones")] 
        public ActionResult<List<TimeZoneDisplay>> Get()
        { 
            return Ok(CultureDateTimeHelper.GetTimeZonesIds());
        } 
    }
}