using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientHospitalizationInformationServices : GenericServicesEntityBaseSimple<PatientHospitalizationInformation,
         AddPatientHospitalizationInformationVO, UpdatePatientHospitalizationInformationVO, GetPatientHospitalizationInformationVO, IPatientHospitalizationInformationBusiness>, IPatientHospitalizationInformationServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientHospitalizationInformationBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientHospitalizationInformationServices(IMapper mapper, IPatientHospitalizationInformationBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        } 

        public async Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId)
        {

            var serviceResponse = new ServiceResponse<List<GetPatientHospitalizationInformationVO>>();
            serviceResponse = await _entityBusiness.FindAllByPatient(patientId);

            return serviceResponse;
        }
    }
}