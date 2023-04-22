using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Principals;
using SmartDigitalPsico.WebAPI.Controllers.v1.SystemDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDigitalPsico.WebAPI.Controllers.v1.Principals
{
    //[Authorize(Roles = "Player")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ApiBaseController
    {
        private readonly IUserServices _entityService;

        public UserController(IUserServices entityService
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
        public async Task<ActionResult<ServiceResponse<List<GetUserVO>>>> FindAll()
        {
            this.setUserIdCurrent();
            return Ok(await _entityService.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetUserVO>>> FindByID(int id)
        {
            this.setUserIdCurrent();
            var response = await _entityService.FindByID(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserVO>>> Create(UserRegisterVO newEntity)
        {
            var response = await _entityService.Create(newEntity);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetUserVO>>> Update(UpdateUserVO updateEntity)
        {
            this.setUserIdCurrent();
            var response = await _entityService.Update(updateEntity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPatch]
        [TypeFilter(typeof(HyperMediaFilter))]//HyperMedia somente verbos que tem retorno 
        public async Task<ActionResult<ServiceResponse<GetUserVO>>> UpdateProfile(UpdateUserProfileVO updateEntity)
        {
            this.setUserIdCurrent();
            var response = await _entityService.UpdateProfile(updateEntity);
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
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        } 
    }
}