using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
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
        public async Task<ActionResult<ServiceResponse<List<GetMedicalFileVO>>>> FindAll(long medicalId)
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindAllByMedical(medicalId));
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
        public async Task<ActionResult> DownloadFileById(long id)
        {
            this.setUserIdCurrent();
            var result = await _entityService.DownloadFileById(id);

            //FileHelper.GetFromByteSaveTemp(result.FileData, result.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ResourcesTemp", result.FileName);
            var fileStream = System.IO.File.OpenRead(filePath);
            var fileBytes = new byte[fileStream.Length];
            fileStream.Read(fileBytes, 0, (int)fileStream.Length);
            fileStream.Close();

            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = result.FileName
            };

            return Ok(response);

            // return Ok("Downloaded");
        }

        [HttpPost("Upload")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> Create([FromForm] AddMedicalFileVOService newEntity)
        {
            this.setUserIdCurrent();
            ServiceResponse<GetMedicalFileVO> response = new ServiceResponse<GetMedicalFileVO>();

            try
            {
                response.Data = null;
                response.Success = await _entityService.PostFileAsync(newEntity);
                response.Message = $"Upload success!";
                if (!response.Success)
                {
                    response.Message = $"Upload fail";
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"Upload fail";
                return BadRequest(response);
            }
        }
    }
}