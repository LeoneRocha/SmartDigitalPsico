using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Business.Validation.Contratcs;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientMedicationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientMedicationInformationBusiness : GenericBusinessEntityBaseSimple<PatientMedicationInformation, AddPatientMedicationInformationVO, UpdatePatientMedicationInformationVO, GetPatientMedicationInformationVO, IPatientMedicationInformationRepository>, IPatientMedicationInformationBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientMedicationInformationRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientMedicationInformationBusiness(IMapper mapper, IPatientMedicationInformationRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository, IValidator<PatientMedicationInformation> entityValidator
            , IApplicationLanguageRepository applicationLanguageRepository, ICacheBusiness cacheBusiness)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
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
            try
            {
                PatientMedicationInformation entityAdd = _mapper.Map<PatientMedicationInformation>(item);


                #region Relationship

                User userAction = await _userRepository.FindByID(this.UserId);
                entityAdd.CreatedUser = userAction;

                Patient patientAdd = await _patientRepository.FindByID(item.PatientId);
                entityAdd.Patient = patientAdd;

                #endregion

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;

                response = await base.Validate(entityAdd);

                if (response.Success)
                {
                    PatientMedicationInformation entityResponse = await _entityRepository.Create(entityAdd);

                    response.Data = _mapper.Map<GetPatientMedicationInformationVO>(entityResponse);
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterCreated", base._applicationLanguageRepository, base._cacheBusiness);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public override async Task<ServiceResponse<GetPatientMedicationInformationVO>> Update(UpdatePatientMedicationInformationVO item)
        {
            ServiceResponse<GetPatientMedicationInformationVO> response = new ServiceResponse<GetPatientMedicationInformationVO>();
            try
            {
                PatientMedicationInformation entityUpdate = await _entityRepository.FindByID(item.Id);

                entityUpdate.ModifyDate = DateTime.Now;
                entityUpdate.LastAccessDate = DateTime.Now;

                User userAction = await _userRepository.FindByID(this.UserId);
                entityUpdate.ModifyUser = userAction;
                entityUpdate.ModifyUserId = this.UserId;

                #region Columns
                entityUpdate.Enable = item.Enable;
                //entityUpdate.Accreditation = item.Accreditation;
                entityUpdate.StartDate = item.StartDate;
                entityUpdate.EndDate = item.EndDate;
                entityUpdate.MainDrug = item.MainDrug;
                entityUpdate.Description = item.Description;
                entityUpdate.Dosage = item.Dosage;
                entityUpdate.Posology = item.Posology;
                #endregion Columns

                response = await base.Validate(entityUpdate);

                if (response.Success)
                {
                    PatientMedicationInformation entityResponse = await _entityRepository.Update(entityUpdate);

                    response.Data = _mapper.Map<GetPatientMedicationInformationVO>(entityResponse);
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterUpdated", base._applicationLanguageRepository, base._cacheBusiness);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientMedicationInformationVO>> response = new ServiceResponse<List<GetPatientMedicationInformationVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);
             
            var recordsList = new RecordsList<PatientMedicationInformation>
            {
                UserIdLogged = base.UserId,
                Records = listResult

            };
            var validator = new PatientMedicationInformationSelectListValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(recordsList);
            if (!validationResult.IsValid)
            {
                response.Errors = validator.GetMapErros(validationResult.Errors);
                response.Success = false;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("ErrorValidator_User_Not_Permission", base._applicationLanguageRepository, base._cacheBusiness);
                return response;
            } 
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

        public async override Task<ServiceResponse<List<GetPatientMedicationInformationVO>>> FindAll()
        {
            var result = new ServiceResponse<List<GetPatientMedicationInformationVO>>();
            result.Success = false;
            result.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);

            return result;
        }
        public async override Task<ServiceResponse<GetPatientMedicationInformationVO>> FindByID(long id)
        {
            return await base.FindByID(id);
        }
    }
}