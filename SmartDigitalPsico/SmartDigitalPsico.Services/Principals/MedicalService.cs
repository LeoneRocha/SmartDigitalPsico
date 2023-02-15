using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Bussines.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Security.Claims;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalService : IMedicalService
    {
        private readonly IMedicalBussines _medicalBussines;
         
        public MedicalService(IMedicalBussines medicalBussines)
        {
            _medicalBussines = medicalBussines;
        }

        public async Task<ServiceResponse<GetMedicalDto>> AddEntity(AddMedicalDto newEntity)
        {
            var serviceResponse = new ServiceResponse<GetMedicalDto>();

            serviceResponse.Data = await _medicalBussines.Add(newEntity);

            return serviceResponse;
        }

        public Task<ServiceResponse<bool>> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetMedicalDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetMedicalDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetMedicalDto>> UpdateEntity(UpdateMedicalDto updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}