using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Services.Contracts.Principals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.PatientFile
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/patient/v{version:apiVersion}/[controller]")]

    public class PatientFileController : ControllerBase
    {
        private readonly IPatientFileServices _entitytService;

        public PatientFileController(IPatientFileServices entitytService)
        {
            _entitytService = entitytService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPatientFileVO>>>> Get()
        { 
            return Ok(await _entitytService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPatientFileVO>>> GetById(int id)
        {
            return Ok(await _entitytService.FindByID(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPatientFileVO>>>> Create(AddPatientFileVO newEntity)
        {
            return Ok(await _entitytService.Create(newEntity));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPatientFileVO>>> Update(UpdatePatientFileVO UpdateEntity)
        { 
            var response = await _entitytService.Update(UpdateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
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