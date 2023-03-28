using AutoMapper;
using FluentValidation;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class ApplicationConfigSettingBusiness
      : GenericBusinessEntityBaseSimple<ApplicationConfigSetting, AddApplicationConfigSettingVO, UpdateApplicationConfigSettingVO, GetApplicationConfigSettingVO, IApplicationConfigSettingRepository>, IApplicationConfigSettingBusiness
    {
        private readonly IMapper _mapper;
        private readonly IApplicationConfigSettingRepository _genericRepository;
       
        public ApplicationConfigSettingBusiness(IMapper mapper, 
            IApplicationConfigSettingRepository entityRepository
            , IValidator<ApplicationConfigSetting> entityValidator)
            : base(mapper, entityRepository, entityValidator   ) {

            _mapper = mapper;
            _genericRepository = entityRepository; 
        } 
    }
}