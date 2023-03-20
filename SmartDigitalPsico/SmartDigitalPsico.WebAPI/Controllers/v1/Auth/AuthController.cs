using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Services.Contracts.Principals;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.Auth
{
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userService;
        public AuthController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<GetUserVO>>> Register(UserRegisterVO newEntity)
        {
            var response = await _userService.Register(newEntity);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<ServiceResponse<GetUserAuthenticatedVO>>> Authenticate(UserLoginVO request)
        {
            var response = await _userService.Login(request.Login, request.Password);             
            if (!response.Success)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }

        [HttpGet("Logout/{login}")]
        public async Task<ActionResult<ServiceResponse<string>>> Logout(UserLoginVO request)
        {
            var response = await _userService.Logout(request.Login);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}