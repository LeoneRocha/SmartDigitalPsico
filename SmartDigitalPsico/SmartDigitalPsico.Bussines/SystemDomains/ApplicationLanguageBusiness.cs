using AutoMapper;
using FluentValidation;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class ApplicationLanguageBusiness
      : GenericBusinessEntityBaseSimple<ApplicationLanguage, AddApplicationLanguageVO, UpdateApplicationLanguageVO, GetApplicationLanguageVO, IApplicationLanguageRepository>, IApplicationLanguageBusiness
    {
        private readonly IMapper _mapper;
        private readonly IApplicationLanguageRepository _genericRepository;
       
        public ApplicationLanguageBusiness(IMapper mapper, IApplicationLanguageRepository entityRepository
             , IValidator<ApplicationLanguage> entityValidator)
            : base(mapper, entityRepository, entityValidator) {

            _mapper = mapper;
            _genericRepository = entityRepository; 
         
        } 
    }
}