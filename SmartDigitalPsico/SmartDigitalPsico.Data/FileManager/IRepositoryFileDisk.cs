using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.FileManager
{
    public interface IRepositoryFileDisk //: IRepositoryFileBase<FileData>
    {
        Task<bool> Save(FileData item);
    }
}
