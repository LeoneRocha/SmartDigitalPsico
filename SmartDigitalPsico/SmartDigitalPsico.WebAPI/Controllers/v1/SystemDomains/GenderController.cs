using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.WebAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [Authorize("Bearer")]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderServices _entityService;
        AuthConfigurationVO _configurationAuth;
        public GenderController(IGenderServices entityService, IOptions<AuthConfigurationVO> configurationAuth)
        {
            _entityService = entityService;
            _configurationAuth = configurationAuth.Value;
        }
        private void setUserCurrent()
        {
            long idUser = SecurityHelperApi.GetUserIdApi(User, _configurationAuth.TypeApiCredential);
            _entityService.SetUserId(idUser);
        }
        //[AllowAnonymous]
        [HttpGet("GetAll")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<List<GetGenderVO>>>> Get()
        {
            setUserCurrent();
            var result = _entityService.FindAll();
            return Ok(await result);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetGenderVO>>> GetById(int id)
        {
            return Ok(await _entityService.FindByID(id));
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetGenderVO>>> Create(AddGenderVO newEntity)
        {
            return Ok(await _entityService.Create(newEntity));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetGenderVO>>> Update(UpdateGenderVO updateEntity)
        {
            //return BadRequest("Em construção"); 
            var response = await _entityService.Update(updateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _entityService.Delete(id);
            if (!response.Data)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}