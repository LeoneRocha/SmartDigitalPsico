using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Services.Contracts.Principals;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.Patient
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


        [HttpGet("Download/{id}")]
        public async Task<ActionResult<ServiceResponse<GetPatientFileVO>>> DownloadFileById(long id)
        {
            var result = await _entitytService.DownloadFileById(id);

            return Ok("Downloaded");
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<string>> Create([FromForm] AddPatientFileVOService newEntity)
        {
            try
            {
                await _entitytService.PostFileAsync(newEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            return Ok($"Upload Succed");
        }

    }
}