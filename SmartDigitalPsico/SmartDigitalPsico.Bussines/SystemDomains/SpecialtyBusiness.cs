using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class SpecialtyBusiness : GenericBusinessEntityBaseSimple<Specialty, ISpecialtyRepository, EntityVOBaseSimple>, ISpecialtyBusiness

    {
        public SpecialtyBusiness(IMapper _mapper, ISpecialtyRepository entityRepository)
            : base(_mapper, entityRepository) { }
    }
}