using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class OfficeBusiness : GenericBusinessEntityBaseSimple<Office, IOfficeRepository, GetOfficeVO>, IOfficeBusiness

    {
        public OfficeBusiness(IMapper _mapper, IOfficeRepository entityRepository)
            : base(_mapper, entityRepository) { }
    }
}