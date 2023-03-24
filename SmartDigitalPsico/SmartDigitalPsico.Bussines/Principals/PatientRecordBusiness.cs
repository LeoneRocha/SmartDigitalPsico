using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientRecord;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientRecordBusiness : GenericBusinessEntityBaseSimple<PatientRecord, AddPatientRecordVO, UpdatePatientRecordVO, GetPatientRecordVO, IPatientRecordRepository>, IPatientRecordBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRecordRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientRecordBusiness(IMapper mapper, IPatientRecordRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IPatientRepository patientRepository
            , IValidator<PatientRecord> entityValidator) 
            : base(mapper, entityRepository, entityValidator)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        public override async Task<ServiceResponse<GetPatientRecordVO>> Create(AddPatientRecordVO item)
        {
            ServiceResponse<GetPatientRecordVO> response = new ServiceResponse<GetPatientRecordVO>();

            PatientRecord entityAdd = _mapper.Map<PatientRecord>(item);

            #region Relationship

            User userAction = await _userRepository.FindByID(this.UserId);
            entityAdd.CreatedUser = userAction;

            Patient patientAdd = await _patientRepository.FindByID(item.PatientId);
            entityAdd.Patient = patientAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            PatientRecord entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientRecordVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async Task<ServiceResponse<List<GetPatientRecordVO>>> FindAllByPatient(long patientId)
        {
            ServiceResponse<List<GetPatientRecordVO>> response = new ServiceResponse<List<GetPatientRecordVO>>();

            var listResult = await _entityRepository.FindAllByPatient(patientId);

            if (listResult == null || listResult.Count == 0)
            {
                response.Success = false;
                response.Message = "Patients not found.";
                return response;
            }
            response.Data = listResult.Select(c => _mapper.Map<GetPatientRecordVO>(c)).ToList();
            response.Success = true;
            response.Message = "Patients finded.";
            return response;
        }
    }
}