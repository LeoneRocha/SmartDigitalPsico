using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IMedicalService
    {
        Task<ServiceResponse<List<GetMedicalDto>>> GetAll();
        Task<ServiceResponse<GetMedicalDto>> GetById(int id);
        Task<ServiceResponse<List<GetMedicalDto>>> AddEntity(AddMedicalDto newEntity);
        Task<ServiceResponse<GetMedicalDto>> UpdateEntity(UpdateMedicalDto updatedEntity);
        Task<ServiceResponse<List<GetMedicalDto>>> DeleteEntity(int id); 
    }
}