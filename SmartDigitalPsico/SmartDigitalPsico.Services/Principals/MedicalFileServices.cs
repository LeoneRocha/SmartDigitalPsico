using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Generic;

namespace SmartDigitalPsico.Services.Principals
{
    public class MedicalFileServices : GenericServicesEntityBaseSimple<MedicalFile, AddMedicalFileVO, UpdateMedicalFileVO, GetMedicalFileVO, IMedicalFileBusiness>, IMedicalFileServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMedicalFileBusiness _entityBusiness;
        private readonly IMapper _mapper;
        public MedicalFileServices(IMapper mapper, IMedicalFileBusiness entityBusiness, IHttpContextAccessor httpContextAccessor)
            : base(mapper, entityBusiness)
        {
            _mapper = mapper;
            _entityBusiness = entityBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetMedicalFileVO> DownloadFileById(long fileId)
        {
            try
            {
                return await _entityBusiness.DownloadFileById(fileId);
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }


        public async Task<bool> PostFileAsync(AddMedicalFileVOService entity)
        {
            try
            {
                AddMedicalFileVO entityAdd = _mapper.Map<AddMedicalFileVO>(entity);
                return await _entityBusiness.PostFileAsync(entityAdd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceResponse<List<GetMedicalFileVO>>> FindAllByMedical(long medicalId)
        {
            var serviceResponse = new ServiceResponse<List<GetMedicalFileVO>>();
            serviceResponse = await _entityBusiness.FindAllByMedical(medicalId);

            return serviceResponse;
        }

    }
}