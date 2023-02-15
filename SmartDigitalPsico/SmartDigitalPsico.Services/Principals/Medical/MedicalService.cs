using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Services.Contracts;
using System.Security.Claims;

namespace CURSO_UDEMY_COGNIZANT_netcore31webapi.Services.CharacterService
{
    public class MedicalService : IMedicalService
    {
        /* private static List<Character> characters = new List<Character>
         {
             new Character(),
             new Character(){ Id = 1 , Name = "Sam" },

         };*/ 

        private readonly IHttpContextAccessor _httpContextAccessor;

        public MedicalService(IHttpContextAccessor httpContextAccessor)
        { 
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<ServiceResponse<List<GetMedicalDto>>> AddEntity(AddMedicalDto newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetMedicalDto>>> DeleteEntity(int id)
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

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        
    }
}