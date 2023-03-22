using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientNotificationMessageServices : GenericServicesEntityBaseSimple<PatientNotificationMessage,
      AddPatientNotificationMessageVO, UpdatePatientNotificationMessageVO, GetPatientNotificationMessageVO, IPatientNotificationMessageBusiness>, IPatientNotificationMessageServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientNotificationMessageBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientNotificationMessageServices(IMapper mapper, IPatientNotificationMessageBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        } 

        public async Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId)
        {

            var serviceResponse = new ServiceResponse<List<GetPatientNotificationMessageVO>>();
            serviceResponse = await _entityBusiness.FindAllByPatient(patientId);

            return serviceResponse;
        }
    }
}