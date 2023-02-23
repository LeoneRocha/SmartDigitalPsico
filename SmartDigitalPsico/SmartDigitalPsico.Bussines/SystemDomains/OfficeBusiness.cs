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
    public class OfficeBusiness : GenericBusinessEntityBaseSimple<Office, AddOfficeVO, GetOfficeVO, GetOfficeVO, IOfficeRepository>, IOfficeBusiness

    {
        private readonly IMapper _mapper; 
        private readonly IOfficeRepository _entityRepository;
        
        public OfficeBusiness(IMapper mapper, IOfficeRepository entityRepository)
            : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _entityRepository = entityRepository;
        } 

    }
}