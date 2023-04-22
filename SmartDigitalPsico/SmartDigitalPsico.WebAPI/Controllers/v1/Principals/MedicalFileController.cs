using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Utils;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains;
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
    [Authorize("Bearer")]
    [Route("api/medical/v{version:apiVersion}/[controller]")]

    public class MedicalFileController : ApiBaseController
    {
        private readonly IMedicalFileServices _entityService;
        public MedicalFileController(IMedicalFileServices entitytService
            , IOptions<AuthConfigurationVO> configurationAuth) : base(configurationAuth)
        {
            _entityService = entitytService;
        }
        private void setUserIdCurrent()
        {
            _entityService.SetUserId(base.GetUserIdCurrent());
        }
         
        [HttpGet("FindAll")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<List<GetMedicalFileVO>>>> Get()
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> FindByID(long id)
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindByID(id));
        }
         
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            this.setUserIdCurrent();
            var response = await _entityService.Delete(id);
            if (response.Data)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("Download/{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> DownloadFileById(long id)
        {
            this.setUserIdCurrent();
            var result = await _entityService.DownloadFileById(id);
            return Ok("Downloaded");
        }

        [HttpPost("Upload")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<string>> Create([FromForm] AddMedicalFileVOService newEntity)
        {
            this.setUserIdCurrent();
            try
            {
                await _entityService.PostFileAsync(newEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            return Ok($"Upload Succed");
        } 
    }
}