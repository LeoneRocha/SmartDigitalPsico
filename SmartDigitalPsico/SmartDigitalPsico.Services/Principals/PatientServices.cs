using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientServices: GenericServicesEntityBase<Patient, IPatientBusiness, GetPatientVO>, IPatientServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientServices(IMapper mapper, IPatientBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetPatientVO>> Create(AddPatientVO item)
        {
            var serviceResponse = new ServiceResponse<GetPatientVO>();

            // item.IdUserAction = GetUserId();

            serviceResponse = await _entityBusiness.Create(item);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPatientVO>> FindByPatient(GetPatientVO info)
        {
            var serviceResponse = new ServiceResponse<GetPatientVO>();
            serviceResponse = await _entityBusiness.FindByPatient(info);

            return serviceResponse;
        }
    }
}