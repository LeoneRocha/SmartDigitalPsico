using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Data.Contract;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Name = request.Username }, request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

       [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Username, request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}