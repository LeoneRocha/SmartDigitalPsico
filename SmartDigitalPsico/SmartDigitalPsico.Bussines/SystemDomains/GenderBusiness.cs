using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.Validation.Helper;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using System.Text;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness
      : GenericBusinessEntityBaseSimple<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderRepository>, IGenderBusiness
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genericRepository;
        private readonly ICacheBusiness _cacheBusiness;
        AuthConfigurationVO _configurationAuth; 
        public GenderBusiness(IMapper mapper, IGenderRepository entityRepository, ICacheBusiness cacheBusiness,
            IOptions<AuthConfigurationVO> configurationAuth,
            IValidator<Gender> entityValidator )
            : base(mapper, entityRepository, entityValidator)
        {
            _mapper = mapper;
            _genericRepository = entityRepository;
            _cacheBusiness = cacheBusiness;
            _configurationAuth = configurationAuth.Value; 
        }

        public override async Task<ServiceResponse<List<GetGenderVO>>> FindAll()
        {
            string keyCache = "FindAll_GetGenderVO";

            ServiceResponse<List<GetGenderVO>> result = new ServiceResponse<List<GetGenderVO>>();
            List<GetGenderVO> listEntity = new List<GetGenderVO>();

            long idu = this.UserId;

            if (_cacheBusiness.IsEnable())
            {
                bool existsCache = _cacheBusiness.TryGet<ServiceResponseCacheVO<List<GetGenderVO>>>(keyCache, out ServiceResponseCacheVO<List<GetGenderVO>> cachedResult);
                if (!existsCache)
                {
                    result = await base.FindAll();
                    ServiceResponseCacheVO<List<GetGenderVO>> cacheSave = new ServiceResponseCacheVO<List<GetGenderVO>>(result, keyCache, _cacheBusiness.GetSlidingExpiration());

                    bool resultAction = _cacheBusiness.Set<ServiceResponseCacheVO<List<GetGenderVO>>>(keyCache, cacheSave);
                }
                else
                {
                    result.Data = cachedResult.Data;
                }
            }
            else
            {
                result = await base.FindAll();
            }

            return result;
        }
        public override async Task<ServiceResponse<GetGenderVO>> Update(UpdateGenderVO item)
        {
            ServiceResponse<GetGenderVO> response = new ServiceResponse<GetGenderVO>();

            bool entityExists = await _genericRepository.Exists(item.Id);

            if (!entityExists)
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            }

            Gender entityUpdate = _mapper.Map<Gender>(item);

            Gender entityFind = await _genericRepository.FindByID(item.Id);

            //Fields not change 
            entityUpdate.CreatedDate = entityFind.CreatedDate;
            entityUpdate.LastAccessDate = entityFind.LastAccessDate;

            //Fields internal change 
            entityUpdate.ModifyDate = DateTime.Now;

            Gender entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<GetGenderVO>(entityResponse);
            response.Success = true;
            response.Message = "Register Updated.";
            return response;

        } 
        public async override Task<ServiceResponse<GetGenderVO>> Create(AddGenderVO item)
        {
            ServiceResponse<GetGenderVO> response = new ServiceResponse<GetGenderVO>();

            var entityValidate = _mapper.Map<Gender>(item);
            response = await this.Validate(entityValidate);

            if (response.Success)
            {
                response = await base.Create(item);
            }

            return response;
        } 
    }
}