using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Patient;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientBusiness : GenericBusinessEntityBase<Patient, IPatientRepository, GetPatientVO>, IPatientBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _entityRepository;
        private readonly IMedicalRepository _medicalRepository;

        public PatientBusiness(IMapper mapper, IPatientRepository entityRepository, IConfiguration configuration, IUserRepository userRepository, IMedicalRepository medicalRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _medicalRepository = medicalRepository;
        }


        public async Task<ServiceResponse<GetPatientVO>> Create(AddPatientVO item)
        {
            ServiceResponse<GetPatientVO> response = new ServiceResponse<GetPatientVO>();

            var patientFinded = await FindByPatient(new GetPatientVO() { Cpf = item.Cpf, Rg = item.Rg, Email = item.Email });

            if (patientFinded != null)
            {
                response.Success = false;
                response.Message = "Patient already exists.";
                return response;
            }
            Patient entityAdd = _mapper.Map<Patient>(item);
              
            #region Relationship

            User userAction = await _userRepository.FindByID(item.IdUserAction);
            entityAdd.CreatedUser = userAction;

            Medical medicalAdd = await _medicalRepository.FindByID(item.MedicalId);
            entityAdd.Medical = medicalAdd;

            #endregion

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            Patient entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetPatientVO>(entityResponse);
            response.Success = true;
            response.Message = "Patient registred.";
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
    }
}