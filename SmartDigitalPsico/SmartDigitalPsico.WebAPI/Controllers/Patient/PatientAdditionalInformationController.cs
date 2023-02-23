using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Services.Contracts.Principals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.Patient
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/patient/v{version:apiVersion}/[controller]")]

    public class PatientAdditionalInformationController : ControllerBase
    {
        private readonly IPatientAdditionalInformationServices _entitytService;

        public PatientAdditionalInformationController(IPatientAdditionalInformationServices PatientAdditionalInformationService)
        {
            _entitytService = PatientAdditionalInformationService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientAdditionalInformationVO>>>> Get()
        {
            //int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _entitytService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPatientAdditionalInformationVO>>> GetById(int id)
        {
            return Ok(await _entitytService.FindByID(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPatientAdditionalInformationVO>>>> Create(AddPatientAdditionalInformationVO newEntity)
        {
            return Ok(await _entitytService.Create(newEntity));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPatientAdditionalInformationVO>>> Update(UpdatePatientAdditionalInformationVO UpdateEntity)
        {
            return BadRequest("Em construção");  // Ok(new EmptyResult());
            //var response = await _entitytService.Update(UpdateEntity);
            //if (response.Data == null)
            //{
            //    return NotFound(response);
            //}
            //return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _entitytService.Delete(id);
            if (response.Data)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}