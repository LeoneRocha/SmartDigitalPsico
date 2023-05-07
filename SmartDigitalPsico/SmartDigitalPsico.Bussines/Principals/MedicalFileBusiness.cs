using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Business.CacheManager;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Business.Validation.Contratcs;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Helpers;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient.PatientHospitalizationInformation;
using SmartDigitalPsico.Model.VO.User;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.FileManager;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalFileBusiness : GenericBusinessEntityBaseSimple<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileRepository>, IMedicalFileBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private readonly IMedicalFileRepository _entityRepository;
        private readonly IMedicalRepository _medicalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryFileDisk _repositoryFileDisk;
        private readonly LocationSaveFileConfigurationVO _locationSaveFileConfigurationVO;

        public MedicalFileBusiness(IMapper mapper, IMedicalFileRepository entityRepository, IMedicalRepository medicalRepository, IConfiguration configuration
            , IUserRepository userRepository, IRepositoryFileDisk repositoryFileDisk
            , IValidator<MedicalFile> entityValidator, IApplicationLanguageRepository applicationLanguageRepository, ICacheBusiness cacheBusiness
            , IOptions<LocationSaveFileConfigurationVO> locationSaveFileConfigurationVO)
            : base(mapper, entityRepository, entityValidator, applicationLanguageRepository, cacheBusiness)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;
            _repositoryFileDisk = repositoryFileDisk;
            _locationSaveFileConfigurationVO = locationSaveFileConfigurationVO.Value;
        }
        public async Task<ServiceResponse<List<GetMedicalFileVO>>> FindAll()
        {
            var result = new ServiceResponse<List<GetMedicalFileVO>>();
            result.Success = false;
            result.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);

            return result;
        }

        public async override Task<ServiceResponse<GetMedicalFileVO>> FindByID(long id)
        {
            ServiceResponse<GetMedicalFileVO> response = new ServiceResponse<GetMedicalFileVO>();
            response = await base.FindByID(id);

            if (string.IsNullOrEmpty(response.Data.FilePath))
            {
                FileHelper.GetFromByteSaveTemp(response?.Data?.FileData, response?.Data?.FileName);
                response.Data.FileUrl = FileHelper.GetFilePath("ResourcesTemp", response?.Data?.FileName);
            } 
            return response;
        }

          
        public async Task<ServiceResponse<List<GetMedicalFileVO>>> FindAllByMedical(long medicalId)
        {
            ServiceResponse<List<GetMedicalFileVO>> response = new ServiceResponse<List<GetMedicalFileVO>>();

            var listResult = await _entityRepository.FindAllByMedical(medicalId);

            var recordsList = new RecordsList<MedicalFile>
            {
                UserIdLogged = base.UserId,
                Records = listResult

            };
            //var validator = new PatientHospitalizationInformationSelectListValidator(_userRepository);
            //var validationResult = await validator.ValidateAsync(recordsList);
            //if (!validationResult.IsValid)
            //{
            //    response.Errors = validator.GetMapErros(validationResult.Errors);
            //    response.Success = false;
            //    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
            //           ("ErrorValidator_User_Not_Permission", base._applicationLanguageRepository, base._cacheBusiness);
            //    return response;
            //}

            //if (listResult == null || listResult.Count == 0)
            //{
            //    response.Success = false;
            //    response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
            //           ("RegisterIsNotFound", base._applicationLanguageRepository, base._cacheBusiness);
            //    return response;
            //}
            response.Data = listResult.Select(c => _mapper.Map<GetMedicalFileVO>(c)).ToList();
            response.Success = true;
            response.Message = await ApplicationLanguageBusiness.GetLocalization<SharedResource>
                       ("RegisterIsFound", base._applicationLanguageRepository, base._cacheBusiness);
            return response;
        }
         
        public override Task<ServiceResponse<GetMedicalFileVO>> Update(UpdateMedicalFileVO item)
        {
            throw new NotImplementedException("Not Permission");
        }

        public async Task<bool> PostFileAsync(AddMedicalFileVO entity)
        {
            ServiceResponse<GetMedicalFileVO> response = new ServiceResponse<GetMedicalFileVO>();
            try
            {
                IFormFile fileData = null;
                if (entity != null)
                {
                    fileData = entity.FileDetails;
                    if (fileData != null)
                    {
                        string extensioFile = fileData.ContentType.Split('/').Last();
                        entity.FilePath = fileData.FileName;
                        entity.FileContentType = fileData.ContentType;
                        entity.FileExtension = extensioFile.Substring(0, 3);
                        entity.FileSizeKB = fileData.Length / 1024;
                    }
                }

                MedicalFile entityAdd = _mapper.Map<MedicalFile>(entity);
                entityAdd.FileName = entity?.FilePath;

                #region Relationship

                entityAdd.Medical = await _medicalRepository.FindByID(entity.MedicalId);

                #endregion Relationship

                entityAdd.CreatedDate = DateTime.Now;
                entityAdd.ModifyDate = DateTime.Now;
                entityAdd.LastAccessDate = DateTime.Now;
                entityAdd.Enable = true;

                User userAction = await _userRepository.FindByID(this.UserId);
                entityAdd.CreatedUser = userAction;

                //response = await base.Validate(entityAdd);
                response.Success = true;
                if (response.Success)
                {
                    entityAdd.FilePath = await persistFile(entity, fileData, entityAdd);
                    MedicalFile entityResponse = await _entityRepository.Create(entityAdd);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public async Task<GetMedicalFileVO> DownloadFileById(long fileId)
        {
            var userAutenticated = await _userRepository.FindByID(this.UserId);

            var fileEntity = await _entityRepository.FindByID(fileId);

            GetMedicalFileVO resultVO = _mapper.Map<GetMedicalFileVO>(fileEntity);

            if (fileEntity != null)
            {
                if (_locationSaveFileConfigurationVO.TypeLocationSaveFiles == ETypeLocationSaveFiles.DataBase && fileEntity.TypeLocationSaveFile == ETypeLocationSaveFiles.DataBase)
                {
                    FileHelper.GetFromByteSaveTemp(fileEntity.FileData, fileEntity.FileName);
                }

                if (_locationSaveFileConfigurationVO.TypeLocationSaveFiles == ETypeLocationSaveFiles.Disk && fileEntity.TypeLocationSaveFile == ETypeLocationSaveFiles.Disk)
                {
                    fileEntity.FileData = await getFromDisk(fileEntity);

                    FileHelper.GetFromByteSaveTemp(fileEntity.FileData, fileEntity.FileName);
                }
            } 

            return resultVO;
        }

        private async Task<string?> persistFile(AddMedicalFileVO entity, IFormFile fileData, MedicalFile entityAdd)
        {
            ///MUDAR PARA BUSCAR NA TABELAS DE CONFIGURACOES  
            string pathDomainBussines = Path.Combine(Directory.GetCurrentDirectory(), "ResourcesFileSave");
            string? folderDest = Path.Combine(pathDomainBussines, entity.MedicalId.ToString());
            var pathSave = Path.Combine(folderDest, fileData.FileName);

            byte[] fileDataSave = await FileHelper.GetByteDataFromIFormFile(fileData);

            if (_locationSaveFileConfigurationVO.TypeLocationSaveFiles == ETypeLocationSaveFiles.DataBase)
            {
                entityAdd.FileData = fileDataSave;
                entityAdd.TypeLocationSaveFile = ETypeLocationSaveFiles.DataBase;
                folderDest = null;
            }
            if (_locationSaveFileConfigurationVO.TypeLocationSaveFiles == ETypeLocationSaveFiles.Disk)
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