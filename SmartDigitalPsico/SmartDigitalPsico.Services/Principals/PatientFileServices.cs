using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientFileServices : GenericServicesEntityBaseSimpleV2<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO, IPatientFileBusiness>, IPatientFileServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientFileBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientFileServices(IMapper mapper, IPatientFileBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

    }
}