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

        [HttpGet("Download/{id}")]
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> DownloadFileById(long id)
        {
            var result = await _entitytService.DownloadFileById(id);

            return Ok("Downloaded");
        }

        [HttpPost]
        public async Task<ActionResult<string>>
            Create([FromForm] AddMedicalFileVOUpload newEntity)
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

        private async Task<string> getFileByBody(AddMedicalFileVO newEntity)
        {
            if (newEntity?.FileData64?.Length > 0)
            {
                var bytes = Convert.FromBase64String(newEntity.FileData64);
                var decodedString = Encoding.UTF8.GetString(bytes);

                return decodedString;
            }
            return string.Empty;
            //return Ok(decodedString);
        }

        private async Task<string> getFileByRequest()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("ResourcesTemp", "FilesUpaload");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //return Ok(new { dbPath });
                return dbPath;

            }
            else
            {
                //return BadRequest();
            }
            return string.Empty;
        }

        private async Task<string> getFileFormDataUpload(IFormFile file)
        {
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var content = await sr.ReadToEndAsync();
                //return Ok(content);
                return content;
            }
            return string.Empty;
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMedicalFileVO>>> Update(UpdateMedicalFileVO UpdateEntity)
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