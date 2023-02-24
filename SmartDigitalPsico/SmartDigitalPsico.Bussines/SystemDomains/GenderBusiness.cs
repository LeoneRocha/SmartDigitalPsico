using AutoMapper;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Contract.SystemDomains;

namespace SmartDigitalPsico.Business.SystemDomains
{
    public class GenderBusiness
      : GenericBussinesEntityBaseSimplev2<Gender, AddGenderVO, UpdateGenderVO, GetGenderVO, IGenderRepository>, IGenderBusiness
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genericRepository;
       
        public GenderBusiness(IMapper mapper, IGenderRepository entityRepository)
            : base(mapper, entityRepository) {

            _mapper = mapper;
            _genericRepository = entityRepository; 
        }
         
        public override async Task<ServiceResponse<GetGenderVO>> Update(UpdateGenderVO item)
        {
            ServiceResponse<GetGenderVO> response = new ServiceResponse<GetGenderVO>();

            bool entityExists = await _genericRepository.Exists(item.Id);

            if (!entityExists)
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            }


            Gender entityUpdate = _mapper.Map<Gender>(item);
            entityUpdate.ModifyDate = DateTime.Now;

            Gender entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<GetGenderVO>(entityResponse);
            response.Success = true;
            response.Message = "Register Updated.";
            return response;
             
        }
    }
}