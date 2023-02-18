using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Services.Contracts.Principals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.Principals
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        //[AllowAnonymous]
        [HttpGet("FindAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalVO>>>> FindAll()
        {
            return Ok(await _userService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> FindByID(int id)
        {
            return Ok(await _userService.FindByID(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> UpdateUser(UpdateUserVO updateEntity)
        {
            var response = await _userService.UpdateUser(updateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _userService.Delete(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }



    }
}