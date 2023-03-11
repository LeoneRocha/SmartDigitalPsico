using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Utils;
using SmartDigitalPsico.Services.Contracts.Principals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.Principals
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")]
    [Route("api/medical/v{version:apiVersion}/[controller]")]

    public class MedicalFileController : ControllerBase
    {
        private readonly IMedicalFileServices _entitytService;

        public MedicalFileController(IMedicalFileServices entitytService)
        {
            _entitytService = entitytService;
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMedicalFileVO>>>> Get()
        {
            return Ok(await _entitytService.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> GetById(long id)
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
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> DownloadFileById(long id)
        {
            var result = await _entitytService.DownloadFileById(id);

            return Ok("Downloaded");
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<string>> Create([FromForm] AddMedicalFileVOService newEntity)
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