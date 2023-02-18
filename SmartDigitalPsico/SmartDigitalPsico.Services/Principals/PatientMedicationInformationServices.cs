using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class PatientMedicationInformationServices : GenericServicesEntityBaseSimple<PatientMedicationInformation, IPatientMedicationInformationBusiness, GetPatientMedicationInformationVO>, IPatientMedicationInformationServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientMedicationInformationBusiness _entityBusiness;
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        public PatientMedicationInformationServices(IMapper mapper, IPatientMedicationInformationBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetPatientMedicationInformationVO>> Create(AddPatientMedicationInformationVO item)
        {
            var serviceResponse = new ServiceResponse<GetPatientMedicationInformationVO>(); 
            serviceResponse = await _entityBusiness.Create(item);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAllByPatient(long patientId)
        {

            var serviceResponse = new ServiceResponse<List<GetPatientMedicationInformationVO>>();
            serviceResponse = await _entityBusiness.FindAllByPatient(patientId);

            return serviceResponse;
        }
    }
}