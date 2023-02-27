using AutoMapper;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalFileBusiness : GenericBussinesEntityBaseSimplev2<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileRepository>, IMedicalFileBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMedicalFileRepository _entityRepository;

        public MedicalFileBusiness(IMapper mapper, IMedicalFileRepository entityRepository, IConfiguration configuration, IUserRepository userRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
        }
    }
}