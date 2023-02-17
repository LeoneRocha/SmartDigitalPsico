using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController] 
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderServices _genderService;

        public GenderController(IGenderServices genderService)
        {
            _genderService = genderService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<EntityVOBaseSimple>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _genderService.FindAll());
        }  
    }
}