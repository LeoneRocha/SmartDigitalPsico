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

    public class MedicalController : ControllerBase
    {
        private readonly IMedicalService _medicalService;

        public MedicalController(IMedicalService medicalService)
        {
            _medicalService = medicalService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalDto>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _medicalService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> GetById(int id)
        {
            return Ok(await _medicalService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalDto>>>> AddMedical(AddMedicalDto newEntity)
        {
            return Ok(await _medicalService.AddEntity(newEntity));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalDto>>> UpdateCharacter(UpdateMedicalDto UpdateEntity)
        {
            var response = await _medicalService.UpdateEntity(UpdateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _medicalService.DeleteEntity(id);
            if (response.Data)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}