using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
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
    [Route("api/medical/v{version:apiVersion}/[controller]")]

    public class MedicalController : ControllerBase
    {
        private readonly IMedicalServices _medicalService;

        public MedicalController(IMedicalServices medicalService)
        {
            _medicalService = medicalService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalVO>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _medicalService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> GetById(int id)
        {
            return Ok(await _medicalService.FindByID(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalVO>>>> Create(AddMedicalVO newEntity)
        {
            return Ok(await _medicalService.Create(newEntity));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> Update(UpdateMedicalVO UpdateEntity)
        {
            return BadRequest("Em construção");  // Ok(new EmptyResult());
            //var response = await _medicalService.Update(UpdateEntity);
            //if (response.Data == null)
            //{
            //    return NotFound(response);
            //}
            //return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _medicalService.Delete(id);
            if (response.Data)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}