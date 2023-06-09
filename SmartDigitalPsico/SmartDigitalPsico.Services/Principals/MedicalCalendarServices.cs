using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical; 
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalCalendarServices : GenericServicesEntityBaseSimple<MedicalCalendar, AddMedicalCalendarVO, UpdateMedicalCalendarVO, GetMedicalCalendarVO, IMedicalCalendarBusiness>, IMedicalCalendarServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalCalendarBusiness _entityBusiness;
        private readonly IMapper _mapper;
        public MedicalCalendarServices(IMapper mapper, IMedicalCalendarBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _mapper = mapper;
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        } 
    }
}