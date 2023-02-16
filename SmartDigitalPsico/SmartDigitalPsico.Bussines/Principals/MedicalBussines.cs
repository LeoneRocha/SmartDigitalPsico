using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using System.Security.Claims;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Data.Repository;
using SmartDigitalPsico.Data.Contract.Principals;
using SmartDigitalPsico.Bussines.Contracts.Principals;

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

            ///MUDAR PARA REPOSITORIO USUARIO
            entityAdd.User = await _userRepository.GetById(newEntity.IdUserAction);
            // await _context.Users.FirstOrDefaultAsync(u => u.Id == newEntity.IdUserAction);

            entityResponse = _mapper.Map<GetMedicalDto>(await _medicalRepository.Add(entityAdd));

            //entityResponse = await _context.Medicals.Where(c =>
            //c.User.Id == newEntity.IdUserAction && c.Accreditation == newEntity.Name)
            //    .Select(c => _mapper.Map<GetMedicalDto>(c)).FirstOrDefaultAsync();

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