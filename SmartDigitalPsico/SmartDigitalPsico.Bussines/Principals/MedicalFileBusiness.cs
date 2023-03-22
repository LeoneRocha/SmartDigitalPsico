using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Utilities;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.FileManager;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalFileBusiness : GenericBusinessEntityBaseSimple<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileRepository>, IMedicalFileBusiness

    {
        private ETypeLocationSaveFiles _localSalvar = ETypeLocationSaveFiles.Disk;
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        //private long _IdUserAction = 1;
        private readonly IMedicalFileRepository _entityRepository;
        private readonly IMedicalRepository _medicalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryFileDisk _repositoryFileDisk;

        public MedicalFileBusiness(IMapper mapper, IMedicalFileRepository entityRepository, IMedicalRepository medicalRepository, IConfiguration configuration
            , IUserRepository userRepository, IRepositoryFileDisk repositoryFileDisk) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;
            _repositoryFileDisk = repositoryFileDisk;
        }
        public override Task<ServiceResponse<bool>> Delete(long id)
        {
            return base.EnableOrDisable(id);
        }

        public async Task<bool> PostFileAsync(AddMedicalFileVO entity)
        { 
            IFormFile fileData = null;
            if (entity != null)
            {
                fileData = entity.FileDetails;
                if (fileData != null)
                {
                    string extensioFile = fileData.ContentType.Split('/').Last();
                    entity.Description = fileData.FileName;
                    entity.FilePath = fileData.FileName;
                    entity.FileContentType = fileData.ContentType;
                    entity.FileExtension = extensioFile.Substring(0, 3);
                    entity.FileSizeKB = fileData.Length / 1024;
                }
            }

            MedicalFile entityAdd = _mapper.Map<MedicalFile>(entity);

            entityAdd.FilePath = await persistFile(entity, fileData, entityAdd);

            #region Relationship

            entityAdd.Medical = await _medicalRepository.FindByID(entity.MedicalId);

            #endregion Relationship

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;
            entityAdd.Enable = true;

            User userAction = await _userRepository.FindByID(entity.IdUserAction);
            entityAdd.CreatedUser = userAction;

            MedicalFile entityResponse = await _entityRepository.Create(entityAdd);

            return true;
        }

        public async Task<bool> DownloadFileById(long fileId)
        {
            var fileEntity = await _entityRepository.FindByID(fileId);

            if (fileEntity != null)
            {
                if (_localSalvar == ETypeLocationSaveFiles.DataBase && fileEntity.TypeLocationSaveFile == ETypeLocationSaveFiles.DataBase)
                {
                    FileHelper.GetFromByteSaveTemp(fileEntity.FileData, fileEntity.Description);
                }

                if (_localSalvar == ETypeLocationSaveFiles.Disk && fileEntity.TypeLocationSaveFile == ETypeLocationSaveFiles.Disk)
                {
                    fileEntity.FileData = await getFromDisk(fileEntity);

                    FileHelper.GetFromByteSaveTemp(fileEntity.FileData, fileEntity.Description);
                }
            }

            return true;
        }

        private async Task<string?> persistFile(AddMedicalFileVO entity, IFormFile fileData, MedicalFile entityAdd)
        {
            ///MUDAR PARA BUSCAR NA TABELAS DE CONFIGURACOES  
            string pathDomainBussines = Path.Combine(Directory.GetCurrentDirectory(), "ResourcesFileSave");
            string? folderDest = Path.Combine(pathDomainBussines, entity.MedicalId.ToString());
            var pathSave = Path.Combine(folderDest, fileData.FileName);

            byte[] fileDataSave = await FileHelper.GetByteDataFromIFormFile(fileData);

            if (_localSalvar == ETypeLocationSaveFiles.DataBase)
            {
                entityAdd.FileData = fileDataSave;
                entityAdd.TypeLocationSaveFile = ETypeLocationSaveFiles.DataBase;
                folderDest = null;
            }
            if (_localSalvar == ETypeLocationSaveFiles.Disk)
            {
                await _repositoryFileDisk.Save(new FileData()
                {
                    FolderDestination = folderDest,
                    FileData = fileDataSave,
                    FileName = fileData.FileName,
                    FilePath = pathSave
                });
                entityAdd.TypeLocationSaveFile = ETypeLocationSaveFiles.Disk;
            }
            return folderDest;
        }

        private async Task<byte[]> getFromDisk(MedicalFile fileEntity)
        {
            return await _repositoryFileDisk.Get(new FileData() { FilePath = fileEntity.FilePath, FileName = fileEntity.Description });
        }
    }
}