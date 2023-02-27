using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Generic
{
    public class GenericBusinessEntityBaseSimplev2<TEntity, TEntityAdd, TEntityUpdate, TEntityResult, Repo>
        : IGenericBusinessEntityBaseSimpleV2<TEntity, TEntityAdd, TEntityUpdate, TEntityResult>
        where TEntity : EntityBaseSimple
        where TEntityAdd : IEntityVOAdd
        where TEntityUpdate : IEntityVO
        where TEntityResult : class
        where Repo : IRepositoryEntityBaseSimple<TEntity>

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;


        public GenericBusinessEntityBaseSimplev2(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Create(TEntityAdd item)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();

            TEntity entityAdd = _mapper.Map<TEntity>(item);

            entityAdd.CreatedDate = DateTime.Now;
            entityAdd.ModifyDate = DateTime.Now;
            entityAdd.LastAccessDate = DateTime.Now; 

            TEntity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<TEntityResult>(entityResponse);
            response.Success = true;
            response.Message = "Register Created.";
            return response;
        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            bool entityResponse = await _genericRepository.Delete(id);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Register Deleted.";
            return response;
        }
        public virtual async Task<ServiceResponse<TEntityResult>> Update(TEntityUpdate item)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();

            bool entityExists = await _genericRepository.Exists(item.Id);

            if (!entityExists)
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            }

            var entityUpdate = _mapper.Map<TEntity>(item);
             
            entityUpdate.ModifyDate = DateTime.Now;  

            TEntity entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<TEntityResult>(entityResponse);
            response.Success = true;
            response.Message = "Register Updated.";
            return response;
        }

        public async Task<ServiceResponse<bool>> Exists(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            bool entityResponse = await _genericRepository.Exists(id);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<List<TEntityResult>>> FindAll()
        {
            ServiceResponse<List<TEntityResult>> response = new ServiceResponse<List<TEntityResult>>();
            List<TEntity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<TEntityResult>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<TEntityResult>> FindByID(long id)
        {
            ServiceResponse<TEntityResult> response = new ServiceResponse<TEntityResult>();
            TEntity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<TEntityResult>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<TEntityResult>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<TEntityResult>> response = new ServiceResponse<List<TEntityResult>>();
            List<TEntity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<TEntityResult>(c)).ToList();
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<int>> GetCount(string query)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            int entityResponse = await _genericRepository.GetCount(query);

            response.Data = entityResponse;
            response.Success = true;
            response.Message = "Registers Counted.";
            return response;
        }

        public virtual async Task<ServiceResponse<bool>> EnableOrDisable(long id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            bool exists = await _genericRepository.Exists(id);
            if (!exists)
            {
                response.Success = false;
                response.Message = "Register not found.";
                return response;
            }
            else
            {
                response.Success = await _genericRepository.EnableOrDisable(id);
                if (response.Success)
                {
                    response.Message = "Register updated.";
                    response.Success = true;
                }
            }

            return response;
        }
    }
}