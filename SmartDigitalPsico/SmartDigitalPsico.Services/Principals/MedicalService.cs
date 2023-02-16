using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Security.Claims;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalService : IMedicalService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IUserBussines _userBussines;
        private readonly IMedicalBussines _medicalBussines; 
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public MedicalService(//IUserBussines userBussines,
            IMedicalBussines medicalBussines,
            IHttpContextAccessor httpContextAccessor)
        {
            //_userBussines = userBussines;
            _medicalBussines = medicalBussines;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetMedicalDto>> AddEntity(AddMedicalDto newEntity)
        {
            var serviceResponse = new ServiceResponse<GetMedicalDto>();

            newEntity.IdUserAction = GetUserId();  // _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
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