using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [Route("[controller]")]

    public class GenderController : ControllerBase
    {
        private readonly IGenderServices _genderService;

        public GenderController(IGenderServices genderService)
        {
            _genderService = genderService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<EntityDTOBaseSimple>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _genderService.FindAll());
        } 

    }
}