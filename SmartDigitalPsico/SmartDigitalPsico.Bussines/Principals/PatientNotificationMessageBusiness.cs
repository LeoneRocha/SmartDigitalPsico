using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientNotificationMessage;
using SmartDigitalPsico.Repository.Contract.Principals;

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
             , IValidator<PatientNotificationMessage> entityValidator) : base(mapper, entityRepository, entityValidator)
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

            PatientNotificationMessage entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientNotificationMessageVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientNotificationMessageVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientNotificationMessageVO>> response = new ServiceResponse<List<GetPatientNotificationMessageVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

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


    }
}