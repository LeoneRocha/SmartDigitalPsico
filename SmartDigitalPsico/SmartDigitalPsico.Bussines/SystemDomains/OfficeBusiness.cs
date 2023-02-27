using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Domains.UpdateVOs;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class OfficeBusiness : GenericBusinessEntityBaseSimplev2<Office, AddOfficeVO, UpdateOfficeVO, GetOfficeVO, IOfficeRepository>, IOfficeBusiness

    {
        public OfficeBusiness(IMapper _mapper, IOfficeRepository entityRepository)
            : base(_mapper, entityRepository) { }
    }
}