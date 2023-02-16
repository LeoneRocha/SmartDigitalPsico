using SmartDigitalPsico.Model.Contracts;

namespace SmartDigitalPsico.Data.Contract.Generic
{
    public interface IRepositoryEntityBase<T> where T : EntityBase
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
