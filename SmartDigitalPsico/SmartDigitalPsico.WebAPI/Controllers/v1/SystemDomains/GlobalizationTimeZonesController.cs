using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Helpers;
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
    public class GlobalizationTimeZonesController : ControllerBase
    {
        public GlobalizationTimeZonesController()
        {
        }
        //[AllowAnonymous]
        [HttpGet("GetTimeZones")]
        public async Task<ActionResult<List<TimeZoneDisplay>>> Get()
        {
            await Task.FromResult(0);
            return Ok(CultureDateTimeHelper.GetTimeZonesIds());
        }
    }
}