using SmartDigitalPsico.Model.Dto.User;

namespace SmartDigitalPsico.Bussines.Contracts
{
    public interface IMedicalBussines
    {
        Task<List<GetMedicalDto>> GetAll();
        Task<GetMedicalDto> GetById(int id);
        Task<List<GetMedicalDto>> Add(AddMedicalDto newEntity);
        Task<GetMedicalDto> Update(UpdateMedicalDto updatedEntity);
        Task<List<GetMedicalDto>> Delete(int id);

    }
}