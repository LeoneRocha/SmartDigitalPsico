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
    public class RoleGroupBusiness : GenericBusinessEntityBaseSimple<RoleGroup, AddRoleGroupVO, UpdateRoleGroupVO, GetRoleGroupVO, IRoleGroupRepository>, IRoleGroupBusiness

    {
        public RoleGroupBusiness(IMapper _mapper, IRoleGroupRepository entityRepository
            , IValidator<RoleGroup> entityValidator, IApplicationLanguageRepository applicationLanguageRepository)
            : base(_mapper, entityRepository, entityValidator, applicationLanguageRepository) { }
    }
}