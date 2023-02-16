using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Bussines.Contracts.Principals
{
    public interface IMedicalBussines
    {
        Task<List<GetMedicalDto>> GetAll();
        Task<GetMedicalDto> GetById(int id);
        Task<GetMedicalDto> Add(AddMedicalDto newEntity);
        Task<GetMedicalDto> Update(UpdateMedicalDto updatedEntity);
        Task<bool> Delete(int id);

    }
}