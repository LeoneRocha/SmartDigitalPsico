using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientHospitalizationInformationBusiness : GenericBusinessEntityBaseSimple<PatientHospitalizationInformation, IPatientHospitalizationInformationRepository, GetPatientHospitalizationInformationVO>, IPatientHospitalizationInformationBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientHospitalizationInformationRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientHospitalizationInformationBusiness(IMapper mapper, IPatientHospitalizationInformationRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        } 

        public async Task<ServiceResponse<GetPatientHospitalizationInformationVO>> Create(AddPatientHospitalizationInformationVO item)
        {
            ServiceResponse<GetPatientHospitalizationInformationVO> response = new ServiceResponse<GetPatientHospitalizationInformationVO>();

            PatientHospitalizationInformation entityAdd = _mapper.Map<PatientHospitalizationInformation>(item);
             
            #region Relationship

            User userAction = await _userRepository.FindByID(item.IdUserAction);
            entityAdd.CreatedUser = userAction;

            Patient patientAdd = await _patientRepository.FindByID(item.PatientId);
            entityAdd.Patient = patientAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            PatientHospitalizationInformation entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientHospitalizationInformationVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientHospitalizationInformationVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientHospitalizationInformationVO>> response = new ServiceResponse<List<GetPatientHospitalizationInformationVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

            if (listResult == null || listResult.Count == 0)
            {
                response.Success = false;
                response.Message = "Patients not found.";
                return response;
            }
            response.Data = listResult.Select(c => _mapper.Map<GetPatientHospitalizationInformationVO>(c)).ToList();  
            response.Success = true;
            response.Message = "Patients finded.";
            return response;
        }

         
    }
}