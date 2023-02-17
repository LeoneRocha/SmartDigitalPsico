using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Contract.Principals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalBusiness : GenericBusinessEntityBase<Medical, IMedicalRepository, GetMedicalDto>, IMedicalBusiness

    {
        private readonly IMapper _mapper;
        private readonly IMedicalRepository _entityRepository;
        private readonly IUserRepository _userRepository;


        IConfiguration _configuration;
        public MedicalBusiness(IMapper mapper, IMedicalRepository entityRepository, IConfiguration configuration,
            IUserRepository userRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
        } 
        public async Task<ServiceResponse<GetMedicalDto>> Create(AddMedicalDto item)
        {
            ServiceResponse<GetMedicalDto> response = new ServiceResponse<GetMedicalDto>();

            if (await Exists(item.Accreditation , item.TypeAccreditation))
            {
                response.Success = false;
                response.Message = "Medical already exists.";
                return response;
            }  
            Medical entityAdd = _mapper.Map<Medical>(item);

            entityAdd.Name = item.Name;
          
            //entityAdd.Office = 
            //entityAdd.Specialties = 

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now; 

            User userAction = await _userRepository.FindByID(item.IdUserAction); 
            entityAdd.CreatedUser = userAction;
             

            Medical entityResponse = await _entityRepository.Create(entityAdd);

            response.Data = _mapper.Map<GetMedicalDto>(entityResponse);
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