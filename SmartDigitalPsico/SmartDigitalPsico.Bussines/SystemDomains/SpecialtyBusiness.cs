using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class SpecialtyBusiness : GenericBusinessEntityBaseSimple<Specialty, AddSpecialtyVO, GetSpecialtyVO, GetSpecialtyVO, ISpecialtyRepository>, ISpecialtyBusiness

    {
        public SpecialtyBusiness(IMapper _mapper, ISpecialtyRepository entityRepository)
            : base(_mapper, entityRepository) { }
    }
}