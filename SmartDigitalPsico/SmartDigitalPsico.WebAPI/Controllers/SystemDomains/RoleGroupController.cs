using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.SystemDomains;
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
    public class RoleGroupController : ControllerBase
    {
        private readonly IRoleGroupServices _entityService;

        public RoleGroupController(IRoleGroupServices entityService)
        {
            _entityService = entityService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<EntityVOBaseSimple>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _entityService.FindAll());
        }
    }
}