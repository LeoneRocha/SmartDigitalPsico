using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        // public async Task<ActionResult<ServiceResponse<List<CultureDisplay>>>> Get() 
        public async Task<ActionResult<List<CultureDisplay>>> Get()
        {
            await Task.FromResult(0);
            return Ok(CultureDateTimeHelper.GetCultures());
        }
    }
}