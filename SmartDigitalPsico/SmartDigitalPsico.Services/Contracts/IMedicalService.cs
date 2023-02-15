using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Services.Contracts
{
    public interface IMedicalService
    {
        Task<ServiceResponse<List<GetMedicalDto>>> GetAll();
        Task<ServiceResponse<GetMedicalDto>> GetById(int id);
        Task<ServiceResponse<GetMedicalDto>> AddEntity(AddMedicalDto newEntity);
        Task<ServiceResponse<GetMedicalDto>> UpdateEntity(UpdateMedicalDto updatedEntity);
        Task<ServiceResponse<bool>> DeleteEntity(int id); 
    }
}