using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientAdditionalInformationBusiness : GenericBusinessEntityBaseSimplev2<PatientAdditionalInformation, AddPatientAdditionalInformationVO, UpdatePatientAdditionalInformationVO, GetPatientAdditionalInformationVO
        , IPatientAdditionalInformationRepository>, IPatientAdditionalInformationBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientAdditionalInformationRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientAdditionalInformationBusiness(IMapper mapper, IPatientAdditionalInformationRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }

        public override async Task<ServiceResponse<GetPatientAdditionalInformationVO>> Create(AddPatientAdditionalInformationVO item)
        {
            ServiceResponse<GetPatientAdditionalInformationVO> response = new ServiceResponse<GetPatientAdditionalInformationVO>();

            PatientAdditionalInformation entityAdd = _mapper.Map<PatientAdditionalInformation>(item);

            #region Relationship

            User userAction = await _userRepository.FindByID(item.IdUserAction);
            entityAdd.CreatedUser = userAction;

            Patient patientAdd = await _patientRepository.FindByID(item.PatientId);
            entityAdd.Patient = patientAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            PatientAdditionalInformation entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientAdditionalInformationVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientAdditionalInformationVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientAdditionalInformationVO>> response = new ServiceResponse<List<GetPatientAdditionalInformationVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

            if (listResult == null || listResult.Count == 0)
            {
                response.Success = false;
                response.Message = "Patients not found.";
                return response;
            }
            response.Data = listResult.Select(c => _mapper.Map<GetPatientAdditionalInformationVO>(c)).ToList();  
            response.Success = true;
            response.Message = "Patients finded.";
            return response;
        }

        
    }
}