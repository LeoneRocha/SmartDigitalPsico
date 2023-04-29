using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Business.Validation.Contratcs;
using SmartDigitalPsico.Business.Validation.Helper;
using SmartDigitalPsico.Business.Validation.PatientValidations.CustomValidator;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using System.Text;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientBusiness : GenericBusinessEntityBase<Patient, AddPatientVO, UpdatePatientVO, GetPatientVO, IPatientRepository>, IPatientBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _entityRepository;
        private readonly IMedicalRepository _medicalRepository;
        private readonly IValidator<Patient> _entityValidator;

        public PatientBusiness(IMapper mapper, IPatientRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IMedicalRepository medicalRepository
            , IValidator<Patient> entityValidator
            , IApplicationLanguageRepository applicationLanguageRepository, ICacheBusiness cacheBusiness)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _medicalRepository = medicalRepository;
            _entityValidator = entityValidator;
        }
        public override async Task<ServiceResponse<GetPatientVO>> Create(AddPatientVO item)
        {
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();
            try
            {
                Patient entityAdd = _mapper.Map<Patient>(item);

                #region Set default fields for bussines

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;

                #endregion Set default fields for bussines

                #region User Action

                User userAction = await _userRepository.FindByID(this.UserId);
                entityAdd.CreatedUser = userAction;

                #endregion User Action
                
                entityAdd.MedicalId = 1; // TESTE ARRUMAR NO FRONT 

                response = await base.Validate(entityAdd);
                if (response.Success)
                {
                    #region Relationship

                    Medical medicalAdd = await _medicalRepository.FindByID(item.MedicalId);
                    entityAdd.Medical = medicalAdd;

                    //Gender gender = await _genderRepository.FindByID(item.MedicalId);
                    entityAdd.GenderId = item.GenderId;

                    #endregion Relationship

                    Patient entityResponse = await _entityRepository.Create(entityAdd);
                    response.Data = _mapper.Map<GetPatientVO>(entityResponse);
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterCreated", base._applicationLanguageRepository, base._cacheBusiness);
                }
            }
            catch (Exception ex)
            {
                //TODO: GENARATE LOGS
                throw ex;
            }
            return response;
        }

        public override async Task<ServiceResponse<GetPatientVO>> Update(UpdatePatientVO item)
        {
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();
            try
            {
                Patient entityUpdate = await _entityRepository.FindByID(item.Id);

                #region Set default fields for bussines

                entityUpdate.ModifyDate = DateTime.Now;
                entityUpdate.LastAccessDate = DateTime.Now;

                #endregion Set default fields for bussines

                #region User Action

                User userAction = await _userRepository.FindByID(this.UserId);
                entityUpdate.ModifyUser = userAction;

                #endregion User Action

                #region Relationship

                //Gender gender = await _genderRepository.FindByID(item.MedicalId);
                entityUpdate.GenderId = item.GenderId;

                #endregion Relationship

                #region Columns
                entityUpdate.Enable = item.Enable;
                entityUpdate.Name = item.Name;
                entityUpdate.Email = item.Email;
                entityUpdate.Cpf = item.Cpf;
                entityUpdate.Rg = item.Rg;
                entityUpdate.Education = item.Education;
                entityUpdate.DateOfBirth = item.DateOfBirth;
                entityUpdate.PhoneNumber = item.PhoneNumber;
                entityUpdate.Profession = item.Profession;

                entityUpdate.EmergencyContactName = item.EmergencyContactName;
                entityUpdate.EmergencyContactPhoneNumber = item.EmergencyContactPhoneNumber;

                entityUpdate.AddressCep = item.AddressCep;
                entityUpdate.AddressCity = item.AddressCity;
                entityUpdate.AddressStreet = item.AddressStreet;
                entityUpdate.AddressState = item.AddressState;
                entityUpdate.AddressNeighborhood = item.AddressNeighborhood;

                #endregion Columns

                response = await base.Validate(entityUpdate);
                if (response.Success)
                {
                    Patient entityResponse = await _entityRepository.Update(entityUpdate);
                    response.Data = _mapper.Map<GetPatientVO>(entityResponse);
                    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterUpdated", base._applicationLanguageRepository, base._cacheBusiness);
                }
            }
            catch (Exception ex)
            {
                //TODO: GENARATE LOGS
                throw ex;
            }
            return response;
        }

        public async Task<ServiceResponse<GetPatientVO>> FindByPatient(GetPatientVO info)
        {
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();

            var patientFind = _mapper.Map<Patient>(info);

            var patientFinded = await _entityRepository.FindByPatient(patientFind);

            if (patientFinded == null)
            {
                response.Success = false;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);
                return response;
            }
            response.Data = _mapper.Map<GetPatientVO>(patientFinded);
            response.Success = true;
            response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsFound", base._applicationLanguageRepository, base._cacheBusiness);
            return response;

        }
        public override async Task<ServiceResponse<List<GetPatientVO>>> FindAll()
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetPatientVO>>> FindAll(long medicalId)
        {
            ServiceResponse<List<GetPatientVO>> response = new ServiceResponse<List<GetPatientVO>>();
            try
            {
                List<Patient> listResult = await _entityRepository.FindAllByMedicalId(medicalId);
                var recordsList = new RecordsList<Patient>
                {
                    UserIdLogged = base.UserId,
                    Records = listResult

                };
                var validator = new PatientSelectListValidator(_userRepository);
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
                response.Data = listResult.Select(c => _mapper.Map<GetPatientVO>(c)).ToList();
                response.Success = true;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsFound", base._applicationLanguageRepository, base._cacheBusiness);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        private async Task<ServiceResponse<List<GetPatientVO>>> validAccessToList(long medicalId)
        {
            ServiceResponse<List<GetPatientVO>> response = new ServiceResponse<List<GetPatientVO>>();
            response.Success = true;

            User userAction = await _userRepository.FindByID(this.UserId);
            var validateResult = PatientPermissionMedicalValidator.ValidatePermissionMedical(medicalId, userAction);
            bool invalidAccess = validateResult != null;
            if (invalidAccess)
            {
                response.Success = false;
                response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsFound", base._applicationLanguageRepository, base._cacheBusiness);

                response.Errors = new List<ErrorResponse>();
                response.Errors.Add(validateResult);
                return response;
            }
            return response;
        }
    }
}