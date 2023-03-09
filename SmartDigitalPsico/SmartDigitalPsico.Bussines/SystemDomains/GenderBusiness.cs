using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.CacheManager;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using System.Collections.Generic;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness
      : GenericBusinessEntityBaseSimplev2<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderRepository>, IGenderBusiness
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genericRepository;
        private readonly ICacheBusiness _cacheBusiness;

        public GenderBusiness(IMapper mapper, IGenderRepository entityRepository, ICacheBusiness cacheBusiness)
            : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _genericRepository = entityRepository;
            _cacheBusiness = cacheBusiness;
        }

        public override async Task<ServiceResponse<List<GetGenderVO>>> FindAll()
        {
            ServiceResponse<List<GetGenderVO>> result = new ServiceResponse<List<GetGenderVO>>();
            List<GetGenderVO> listEntity = new List<GetGenderVO>();

            if (_cacheBusiness.IsEnable())
            {
                bool existsCache = _cacheBusiness.TryGet<ServiceResponseCacheVO<List<GetGenderVO>>>("FindAll_GetGenderVO",
              out ServiceResponseCacheVO<List<GetGenderVO>> cachedResult);
                if (!existsCache)
                {
                    result = await base.FindAll();
                    ServiceResponseCacheVO<List<GetGenderVO>> cacheSave = new ServiceResponseCacheVO<List<GetGenderVO>>(result, _cacheBusiness.GetSlidingExpiration());

                    bool resultAction = _cacheBusiness.Set<ServiceResponseCacheVO<List<GetGenderVO>>>("FindAll_GetGenderVO", cacheSave);
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
            entityUpdate.ModifyDate = DateTime.Now;

            Gender entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<GetGenderVO>(entityResponse);
            response.Success = true;
            response.Message = "Register Updated.";
            return response;

        }
    }
}