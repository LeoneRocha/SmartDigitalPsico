using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientMedicationInformationBusiness : GenericBusinessEntityBaseSimple<PatientMedicationInformation, AddPatientMedicationInformationVO, UpdatePatientMedicationInformationVO, GetPatientMedicationInformationVO, IPatientMedicationInformationRepository>, IPatientMedicationInformationBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientMedicationInformationRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientMedicationInformationBusiness(IMapper mapper, IPatientMedicationInformationRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        public override async Task<ServiceResponse<GetPatientMedicationInformationVO>> Create(AddPatientMedicationInformationVO item)
        {
            ServiceResponse<GetPatientMedicationInformationVO> response = new ServiceResponse<GetPatientMedicationInformationVO>();

            PatientMedicationInformation entityAdd = _mapper.Map<PatientMedicationInformation>(item);

            #region Relationship

            User userAction = await _userRepository.FindByID(this.UserId);
            //entityAdd.CreatedUser = userAction;

            Patient patientAdd = await _patientRepository.FindByID(item.PatientId);
            entityAdd.Patient = patientAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            PatientMedicationInformation entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientMedicationInformationVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientMedicationInformationVO>> response = new ServiceResponse<List<GetPatientMedicationInformationVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

            if (listResult == null || listResult.Count == 0)
            {
                response.Success = false;
                response.Message = "Patients not found.";
                return response;
            }
            response.Data = listResult.Select(c => _mapper.Map<GetPatientMedicationInformationVO>(c)).ToList();
            response.Success = true;
            response.Message = "Patients finded.";
            return response;
        }
    }
}