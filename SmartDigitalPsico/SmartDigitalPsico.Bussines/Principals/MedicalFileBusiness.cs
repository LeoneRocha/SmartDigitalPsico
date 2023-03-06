using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Utilities;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Generic;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Repository.Contract.Principals;

namespace SmartDigitalPsico.Business.Principals
{
    public class MedicalFileBusiness : GenericBusinessEntityBaseSimplev2<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileRepository>, IMedicalFileBusiness

    {
        private readonly IMapper _mapper;
        IConfiguration _configuration;
        private long _IdUserAction = 1;
        private readonly IMedicalFileRepository _entityRepository;
        private readonly IMedicalRepository _medicalRepository;
        private readonly IUserRepository _userRepository;

        public MedicalFileBusiness(IMapper mapper, IMedicalFileRepository entityRepository, IMedicalRepository medicalRepository, IConfiguration configuration, IUserRepository userRepository) : base(mapper, entityRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _entityRepository = entityRepository;
            _medicalRepository = medicalRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> PostFileAsync(AddMedicalFileVOUpload entity)
        {
            var addMedicalFileVO = new AddMedicalFileVO();
            if (entity != null)
            {

                addMedicalFileVO.Description = entity.Description;
                addMedicalFileVO.MedicalId = entity.MedicalId;
                var fileData = entity.FileDetails;
                if (fileData != null)
                {
                    string extensioFile = fileData.ContentType.Split('/').Last();
                    addMedicalFileVO.Description = fileData.FileName;
                    addMedicalFileVO.FilePath = fileData.FileName;
                    addMedicalFileVO.FileContentType = fileData.ContentType;
                    addMedicalFileVO.FileExtension = extensioFile.Substring(0, 3);
                    addMedicalFileVO.FileSizeKB = fileData.Length / 1024;

                    using (var stream = new MemoryStream())
                    {
                        await fileData.CopyToAsync(stream);
                        addMedicalFileVO.FileData = stream.ToArray();
                    }
                }
            }

            MedicalFile entityAdd = _mapper.Map<MedicalFile>(addMedicalFileVO);

            #region Relationship

            entityAdd.Medical = await _medicalRepository.FindByID(addMedicalFileVO.MedicalId);

            #endregion Relationship

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now;
            entityAdd.Enable = true;

            User userAction = await _userRepository.FindByID(_IdUserAction);
            entityAdd.CreatedUser = userAction;

            MedicalFile entityResponse = await _entityRepository.Create(entityAdd);

            return true;
        }

        public async Task<bool> DownloadFileById(long fileId)
        {
            var fileEntity = await _entityRepository.FindByID(fileId);

            if (fileEntity != null)
            {
                var content = new System.IO.MemoryStream(fileEntity.FileData);

                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "ResourcesTemp",
                   fileEntity.Description);

                await copyStream(content, path);

                return true;
            }

            return false;
        }
        private async Task copyStream(MemoryStream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}