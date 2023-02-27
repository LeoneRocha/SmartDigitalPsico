using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientFileBusiness : GenericBusinessEntityBaseSimplev2<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO, IPatientFileRepository>, IPatientFileBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientFileRepository _entityRepository;

        public PatientFileBusiness(IMapper mapper, IPatientFileRepository entityRepository, IConfiguration configuration, IUserRepository userRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
        }
    }
}