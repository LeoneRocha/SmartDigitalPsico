using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.SystemDomains
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeServices _entityService;

        public OfficeController(IOfficeServices entityService)
        {
            _entityService = entityService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<List<GetOfficeVO>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _entityService.FindAll());
        }
    }
}