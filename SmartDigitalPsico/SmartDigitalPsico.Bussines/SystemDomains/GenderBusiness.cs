using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness : GenericBusinessEntityBaseSimple<Gender, IGenderRepository, GetGenderVO>, IGenderBusiness

    {
        public GenderBusiness(IMapper _mapper, IGenderRepository _genderRepository)
            : base(_mapper, _genderRepository) { }
    }
}