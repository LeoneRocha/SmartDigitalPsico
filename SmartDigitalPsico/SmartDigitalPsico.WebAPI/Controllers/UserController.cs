using Azure;
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

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[AllowAnonymous]
        [HttpGet("FindAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalDto>>>> FindAll()
        {
           return Ok(await _userService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> FindByID(int id)
        {
            return Ok(await _userService.FindByID(id));
        } 

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> UpdateUser(UpdateUserDto updateEntity)
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