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
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalBusiness : GenericBusinessEntityBase<Medical, IMedicalRepository, GetMedicalVO>, IMedicalBusiness

    {
        private readonly IMapper _mapper;
        private readonly IMedicalRepository _entityRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        IConfiguration _configuration;
        public MedicalBusiness(IMapper mapper, IMedicalRepository entityRepository, IConfiguration configuration,
            IUserRepository userRepository, IOfficeRepository officeRepository, ISpecialtyRepository specialtyRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _officeRepository = officeRepository;
            _specialtyRepository = specialtyRepository;
        }
        public async Task<ServiceResponse<GetMedicalVO>> Create(AddMedicalVO item)
        {
            ServiceResponse<GetMedicalVO> response = new ServiceResponse<GetMedicalVO>();

            if (await Exists(item.Accreditation, item.TypeAccreditation))
            {
                response.Success = false;
                response.Message = "Medical already exists.";
                return response;
            }
            Medical entityAdd = _mapper.Map<Medical>(item);
           
            #region Relationship

            entityAdd.Office = await _officeRepository.FindByID(item.OfficeId); 
          
            List<Specialty> specialtiesAdd = await _specialtyRepository.FindByIDs(item.SpecialtiesIds);
            entityAdd.Specialties = specialtiesAdd;

            #endregion Relationship

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;

            User userAction = await _userRepository.FindByID(item.IdUserAction);
            entityAdd.CreatedUser = userAction;


            Medical entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetMedicalVO>(entityResponse);
            response.Success = true;
            response.Message = "Medical registred.";
            return response;
        }

        private async Task<bool> Exists(string accreditation, ETypeAccreditation typeAccreditation)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            bool entityResponse = await _entityRepository.Exists(accreditation);

            return entityResponse;
        }
    }
}