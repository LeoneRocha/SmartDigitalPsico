using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Patient.PatientFile;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.FileManager;

namespace SmartDigitalPsico.Business.Principals
{
    public class PatientFileBusiness : GenericBusinessEntityBaseSimple<PatientFile, AddPatientFileVO, UpdatePatientFileVO, GetPatientFileVO, IPatientFileRepository>, IPatientFileBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private ETypeLocationSaveFiles _localSalvar = ETypeLocationSaveFiles.Disk;
        private readonly IUserRepository _userRepository;
        private readonly IPatientFileRepository _entityRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IRepositoryFileDisk _repositoryFileDisk;

        public PatientFileBusiness(IMapper mapper, IPatientFileRepository entityRepository, IConfiguration configuration,
            IUserRepository userRepository, IPatientRepository patientRepository
            , IValidator<PatientFile> entityValidator, IApplicationLanguageRepository applicationLanguageRepository)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }

        public override Task<ServiceResponse<bool>> Delete(long id)
        {
            return base.EnableOrDisable(id);
        }

        public async Task<bool> PostFileAsync(AddPatientFileVO entity)
        {
            ServiceResponse<GetPatientFileVO> response = new ServiceResponse<GetPatientFileVO>();

            try
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

                PatientFile entityAdd = _mapper.Map<PatientFile>(entity);

                #region Relationship

                entityAdd.Patient = await _patientRepository.FindByID(entity.PatientId);

                #endregion Relationship

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;
                entityAdd.Enable = true;

                User userAction = await _userRepository.FindByID(this.UserId);
                entityAdd.CreatedUser = userAction;

                response = await base.Validate(entityAdd);

                if (response.Success)
                {
                    entityAdd.FilePath = await persistFile(entity, fileData, entityAdd);
                    PatientFile entityResponse = await _entityRepository.Create(entityAdd);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public async Task<bool> DownloadFileById(long fileId)
        {
            var userAutenticated = await _userRepository.FindByID(this.UserId);

            var fileEntity = await _entityRepository.FindByID(fileId);

            if (userAutenticated != null && fileEntity != null
                && fileEntity?.Patient.Medical.Id == userAutenticated?.Medical?.Id)
            {
                return false;
            }
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

        private async Task<string?> persistFile(AddPatientFileVO entity, IFormFile fileData, PatientFile entityAdd)
        {
            ///MUDAR PARA BUSCAR NA TABELAS DE CONFIGURACOES  
            string pathDomainBussines = Path.Combine(Directory.GetCurrentDirectory(), "ResourcesFileSave");
            string? folderDest = Path.Combine(pathDomainBussines, entity.PatientId.ToString());
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

        private async Task<byte[]> getFromDisk(PatientFile fileEntity)
        {
            return await _repositoryFileDisk.Get(new FileData() { FilePath = fileEntity.FilePath, FileName = fileEntity.Description });
        }

    }
}