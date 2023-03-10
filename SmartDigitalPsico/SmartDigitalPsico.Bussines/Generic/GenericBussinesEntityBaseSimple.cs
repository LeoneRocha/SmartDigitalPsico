using AutoMapper;
using SmartDigitalPsico.Business.Generic.Contracts;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Business.Generic
{
    public class GenericBusinessEntityBaseSimple<Entity, Repo, EntityVO>
        : IGenericBusinessEntityBaseSimple<Entity, EntityVO>
        where Entity : EntityBaseSimple
        where Repo : IRepositoryEntityBaseSimple<Entity>
        where EntityVO : class

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        public GenericBusinessEntityBaseSimple(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<EntityVO>> Create(EntityVO item)
        {
            ServiceResponse<EntityVO> response = new ServiceResponse<EntityVO>();

            Entity entityAdd = _mapper.Map<Entity>(item);

            Entity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<EntityVO>(entityResponse);
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
        public virtual async Task<ServiceResponse<EntityVO>> Update(EntityVO item)
        {
            ServiceResponse<EntityVO> response = new ServiceResponse<EntityVO>();

            var entityUpdate = _mapper.Map<Entity>(item);
            Entity entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<EntityVO>(entityResponse);
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
        public async Task<ServiceResponse<List<EntityVO>>> FindAll()
        {
            ServiceResponse<List<EntityVO>> response = new ServiceResponse<List<EntityVO>>();
            List<Entity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<EntityVO>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<EntityVO>> FindByID(long id)
        {
            ServiceResponse<EntityVO> response = new ServiceResponse<EntityVO>();
            Entity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<EntityVO>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<EntityVO>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<EntityVO>> response = new ServiceResponse<List<EntityVO>>();
            List<Entity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<EntityVO>(c)).ToList();
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