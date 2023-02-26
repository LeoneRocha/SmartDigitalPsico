using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class ApplicationLanguageBusiness
      : GenericBussinesEntityBaseSimplev2<ApplicationLanguage, AddApplicationLanguageVO, UpdateApplicationLanguageVO, GetApplicationLanguageVO, IApplicationLanguageRepository>, IApplicationLanguageBusiness
    {
        private readonly IMapper _mapper;
        private readonly IApplicationLanguageRepository _genericRepository;
       
        public ApplicationLanguageBusiness(IMapper mapper, IApplicationLanguageRepository entityRepository)
            : base(mapper, entityRepository) {

            _mapper = mapper;
            _genericRepository = entityRepository; 
        } 
    }
}