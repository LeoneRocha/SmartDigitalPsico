using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.Principals
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    //[Authorize("Bearer")] 
    [Route("api/medical/v{version:apiVersion}/[controller]")]

    public class MedicalController : ApiBaseController
    {
        private readonly IMedicalServices _entityService;
        public MedicalController(IMedicalServices entityService
            , IOptions<AuthConfigurationVO> configurationAuth) : base(configurationAuth)
        {
            _entityService = entityService;
        }
        private void setUserIdCurrent()
        {
            _entityService.SetUserId(base.GetUserIdCurrent());
        }
         
        [HttpGet("FindAll")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<List<GetMedicalVO>>>> Get()
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> GetById(int id)
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindByID(id));
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> Create(AddMedicalVO newEntity)
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.Create(newEntity));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetMedicalVO>>> Update(UpdateMedicalVO UpdateEntity)
        {
            this.setUserIdCurrent(); 
            var response = await _entityService.Update(UpdateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
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

    }
}