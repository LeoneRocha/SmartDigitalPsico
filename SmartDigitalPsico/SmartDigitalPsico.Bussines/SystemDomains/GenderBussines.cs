using AutoMapper;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.Principals
{
    public class GenderBusiness : GenericBusinessEntityBaseSimple<Gender, IGenderRepository, EntityVOBaseSimple>, IGenderBusiness

    {
        public GenderBusiness(IMapper _mapper, IGenderRepository _genderRepository)
            : base(_mapper, _genderRepository) { }
    }
}