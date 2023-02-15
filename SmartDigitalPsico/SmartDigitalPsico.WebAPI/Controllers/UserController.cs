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
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalDto>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }
         
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(UserRegisterDto newEntity)
        {
            var response = await _userService.Register(newEntity);

            if (!response.Success)
            {
                return BadRequest(response);
            } 
            return Ok(response); 
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> UpdateUser(UpdateUserDto updateEntity)
        {
            var response = await _userService.UpdateEntity(updateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _userService.DeleteEntity(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}