using AutoMapper;
using FluentValidation;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class SpecialtyBusiness
        : GenericBusinessEntityBaseSimple<Specialty, AddSpecialtyVO, UpdateSpecialtyVO, GetSpecialtyVO, ISpecialtyRepository>, ISpecialtyBusiness
    {
        public SpecialtyBusiness(IMapper _mapper, ISpecialtyRepository entityRepository, IValidator<Specialty> entityValidator, IApplicationLanguageRepository applicationLanguageRepository)
            : base(_mapper, entityRepository, entityValidator, applicationLanguageRepository) { }
    }
}