using AutoMapper;
using FluentValidation;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class OfficeBusiness : GenericBusinessEntityBaseSimple<Office, AddOfficeVO, UpdateOfficeVO, GetOfficeVO, IOfficeRepository>, IOfficeBusiness

    {
        public OfficeBusiness(IMapper _mapper, IOfficeRepository entityRepository, IValidator<Office> entityValidator, IApplicationLanguageRepository applicationLanguageRepository)
            : base(_mapper, entityRepository, entityValidator, applicationLanguageRepository) { }
    }
}