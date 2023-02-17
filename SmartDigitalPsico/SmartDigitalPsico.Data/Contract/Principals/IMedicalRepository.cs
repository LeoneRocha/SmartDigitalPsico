using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IMedicalRepository
    {
        Task<List<Medical>> GetAll();
        Task<Medical> GetById(int id);
        Task<Medical> Add(Medical newEntity);
        Task<Medical> Update(Medical updatedEntity);
        Task<bool> Delete(int id);
    }
}