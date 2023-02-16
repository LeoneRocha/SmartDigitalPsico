using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Data.Contract.Principals
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