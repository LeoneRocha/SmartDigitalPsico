using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness : GenericBusinessEntityBaseSimple<Gender, AddGenderVO, GetGenderVO, GetGenderVO, IGenderRepository>, IGenderBusiness

    { 
        private readonly IMapper _mapper; 
        private readonly IGenderRepository _entityRepository;

        public GenderBusiness(IMapper mapper, IGenderRepository entityRepository)
            : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _entityRepository = entityRepository;
        } 

            
    }
}