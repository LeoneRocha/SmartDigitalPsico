using AutoMapper;
using SmartDigitalPsico.Bussines.Contracts;
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Model.Dto.User;
using System.Security.Claims;

namespace SmartDigitalPsico.Bussines.Principals.Medical
{
    public class MedicalBussines : IMedicalBussines
    {

        private readonly IMapper _mapper;
        private readonly SmartDigitalPsicoDataContext _context;

        public MedicalBussines(IMapper mapper, SmartDigitalPsicoDataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<List<GetMedicalDto>> Add(AddMedicalDto newCharacter)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetMedicalDto>> Delete(int id)
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