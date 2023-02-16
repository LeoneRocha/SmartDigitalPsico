using AutoMapper;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Bussines.Principals
{
    public class MedicalBussines : IMedicalBussines
    {
        private readonly IMapper _mapper;
        private readonly IMedicalRepository _medicalRepository;
        private readonly IUserRepository _userRepository;
         
        public MedicalBussines(IMapper mapper, IMedicalRepository medicalRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;
        }

        public async Task<GetMedicalDto> Add(AddMedicalDto newEntity)
        {
            var entityResponse = new GetMedicalDto();
            Medical entityAdd = _mapper.Map<Medical>(newEntity);
             
            entityAdd.User = await _userRepository.FindByID(newEntity.IdUserAction); 

            entityResponse = _mapper.Map<GetMedicalDto>(await _medicalRepository.Add(entityAdd)); 

            return entityResponse;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetMedicalDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GetMedicalDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMedicalDto> Update(UpdateMedicalDto updatedCharacter)
        {
            throw new NotImplementedException();
        } 
    }
}