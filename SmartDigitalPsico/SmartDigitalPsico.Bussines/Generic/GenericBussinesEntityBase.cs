using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Generic
{
    public class GenericBusinessEntityBase<Entity, Repo, ResultEntity>
        : IGenericBusinessEntityBase<Entity, ResultEntity>
        where Entity : EntityBase
        where Repo : IRepositoryEntityBase<Entity>
        where ResultEntity : class

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        public GenericBusinessEntityBase(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<ResultEntity>> Create(ResultEntity item)
        {
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();

            Entity entityAdd = _mapper.Map<Entity>(item);

            Entity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<ResultEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register Created.";
            return response;
        }
        public virtual async Task<ServiceResponse<bool>> Delete(long id)
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
                response.Success = await _genericRepository.Delete(id); 
                if (response.Success)
                {
                    response.Message = "Register deleted.";
                    response.Success = true;
                }
            } 

            return response;
        }
        public virtual async Task<ServiceResponse<ResultEntity>> Update(ResultEntity item)
        {
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();

            var entityUpdate = _mapper.Map<Entity>(item);
            Entity entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<ResultEntity>(entityResponse);
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
        public async Task<ServiceResponse<List<ResultEntity>>> FindAll()
        {
            ServiceResponse<List<ResultEntity>> response = new ServiceResponse<List<ResultEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<ResultEntity>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<ResultEntity>> FindByID(long id)
        {
            ServiceResponse<ResultEntity> response = new ServiceResponse<ResultEntity>();
            Entity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<ResultEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<ResultEntity>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<ResultEntity>> response = new ServiceResponse<List<ResultEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<ResultEntity>(c)).ToList();
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