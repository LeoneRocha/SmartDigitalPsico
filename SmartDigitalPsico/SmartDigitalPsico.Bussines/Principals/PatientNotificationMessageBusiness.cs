using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientNotificationMessageBusiness
        : GenericBusinessEntityBaseSimple<PatientNotificationMessage, AddPatientNotificationMessageVO, UpdatePatientNotificationMessageVO, GetPatientNotificationMessageVO, IPatientNotificationMessageRepository>, IPatientNotificationMessageBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientNotificationMessageRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientNotificationMessageBusiness(IMapper mapper, IPatientNotificationMessageRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository
             , IValidator<PatientNotificationMessage> entityValidator, IApplicationLanguageRepository applicationLanguageRepository, ICacheBusiness cacheBusiness) 
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        public override async Task<ServiceResponse<GetPatientNotificationMessageVO>> Create(AddPatientNotificationMessageVO item)
        {
            ServiceResponse<GetPatientNotificationMessageVO> response = new ServiceResponse<GetPatientNotificationMessageVO>();
            try
            {
                PatientNotificationMessage entityAdd = _mapper.Map<PatientNotificationMessage>(item);

                #region Relationship

                User userAction = await _userRepository.FindByID(this.UserId);
                entityAdd.CreatedUser = userAction;

                Patient patientAdd = await _patientRepository.FindByPatient(new Patient() { Cpf = item.Cpf, Rg = item.Rg, Email = item.Email });
                entityAdd.Patient = patientAdd;

                #endregion

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;
                response = await base.Validate(entityAdd);

                if (response.Success)
                {
                    PatientNotificationMessage entityResponse = await _entityRepository.Create(entityAdd);

                    response.Data = _mapper.Map<GetPatientNotificationMessageVO>(entityResponse);
                    response.Success = true;
                    response.Message = "Patient registred.";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
         
        public override async Task<ServiceResponse<GetPatientNotificationMessageVO>> Update(UpdatePatientNotificationMessageVO item)
        {
            ServiceResponse<GetPatientNotificationMessageVO> response = new ServiceResponse<GetPatientNotificationMessageVO>();
            try
            {
                PatientNotificationMessage entityUpdate = await _entityRepository.FindByID(item.Id);

                #region Relationship
                  
                #endregion Relationship

                entityUpdate.ModifyDate = DateTime.Now;
                entityUpdate.LastAccessDate = DateTime.Now;

                User userAction = await _userRepository.FindByID(this.UserId);
                entityUpdate.ModifyUser = userAction;
                entityUpdate.ModifyUserId = this.UserId;

                #region Columns
                entityUpdate.Enable = item.Enable;
                entityUpdate.MessagePatient = item.Message;
                
                entityUpdate.IsReaded = item.IsReaded;                
                entityUpdate.ReadingDate = item.IsReaded ? DateTime.Now : null;

                entityUpdate.Notified = item.Notified;
                entityUpdate.NotifiedDate = item.Notified ? DateTime.Now : null;

                #endregion Columns

                response = await base.Validate(entityUpdate);

                if (response.Success)
                {
                    PatientNotificationMessage entityResponse = await _entityRepository.Update(entityUpdate);

                    response.Data = _mapper.Map<GetPatientNotificationMessageVO>(entityResponse);
                    response.Message = "Medical updated.";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }
        public async Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientNotificationMessageVO>> response = new ServiceResponse<List<GetPatientNotificationMessageVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

            //TODO:VALIDATE USER GET REGISTER

            if (listResult == null || listResult.Count == 0)
            {
                response.Success = false;
                response.Message = "Patients not found.";
                return response;
            }
            response.Data = listResult.Select(c => _mapper.Map<GetPatientNotificationMessageVO>(c)).ToList();
            response.Success = true;
            response.Message = "Patients finded.";
            return response;
        }

        public async override Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAll()
        {
            var result = new ServiceResponse<List<GetPatientNotificationMessageVO>>();
            result.Success = false;
            result.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);

            return result;
        }
        public async override Task<ServiceResponse<GetPatientNotificationMessageVO>> FindByID(long id)
        {
            return await base.FindByID(id);
        }

    }
}