using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.GetVOs;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Repository.Contract.Principals;
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
            , IValidator<Patient> entityValidator) : base(mapper, entityRepository)
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

            Patient entityAdd = _mapper.Map<Patient>(item);
                   
            #region Relationship

            User userAction = await _userRepository.FindByID(this.UserId);
            entityAdd.CreatedUser = userAction;

            Medical medicalAdd = await _medicalRepository.FindByID(item.MedicalId);
            entityAdd.Medical = medicalAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            response = await validate(item, entityAdd);

            Patient entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
            return response;
        }

        public async override Task<ServiceResponse<GetPatientVO>> Validate(Patient entity)
        {//
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();

            //var validator = new GenderValidator();
            var validationResult = await _entityValidator.ValidateAsync(entity);

            response.Success = validationResult.IsValid;

            if (!validationResult.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var failure in validationResult.Errors)
                {
                    sb.Append("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                response.Message = sb.ToString();
            }
            return response;
        }
        
        public override Task<ServiceResponse<GetPatientVO>> Update(UpdatePatientVO item)
        {
            return base.Update(item);   
        } 

        private async Task<ServiceResponse<GetPatientVO>> validate(AddPatientVO item, Patient entityAdd)
        {
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();
             
            var patientFinded = await FindByPatient(new GetPatientVO() { Cpf = item.Cpf, Rg = item.Rg, Email = item.Email });

            if (patientFinded != null)
            {
                response.Success = false;
                response.Message = "Patient already exists."; 
            }

            response = await this.Validate(entityAdd); 
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
                response.Message = "Patient not found.";
                return response;
            }
            response.Data = _mapper.Map<GetPatientVO>(patientFinded);
            response.Success = true;
            response.Message = "Patient finded.";
            return response;

        }
        public Task<ServiceResponse<List<GetPatientVO>>> FindAll(long medicalId)
        {
            throw new NotImplementedException();
        }
    }
}