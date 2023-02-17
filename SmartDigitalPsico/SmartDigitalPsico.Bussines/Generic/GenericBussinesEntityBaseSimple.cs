using AutoMapper;
using SmartDigitalPsico.Bussines.Generic.Contracts;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Bussines.Generic
{
    public class GenericBussinesEntityBaseSimple<Entity, Repo, ResutEntity>
        : IGenericBussinesEntityBaseSimple<Entity, ResutEntity>
        where Entity : EntityBaseSimple
        where Repo : IRepositoryEntityBaseSimple<Entity>
        where ResutEntity : EntityDTOBaseSimple

    {
        private readonly IMapper _mapper;
        private readonly Repo _genericRepository;
        public GenericBussinesEntityBaseSimple(IMapper mapper, Repo UserRepository)
        {
            _mapper = mapper;
            _genericRepository = UserRepository;
        }
        public virtual async Task<ServiceResponse<ResutEntity>> Create(ResutEntity item)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();

            Entity entityAdd = _mapper.Map<Entity>(item);

            Entity entityResponse = await _genericRepository.Create(entityAdd);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
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
        public virtual async Task<ServiceResponse<ResutEntity>> Update(ResutEntity item)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();

            var entityUpdate = _mapper.Map<Entity>(item);
            Entity entityResponse = await _genericRepository.Update(entityUpdate);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
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
        public async Task<ServiceResponse<List<ResutEntity>>> FindAll()
        {
            ServiceResponse<List<ResutEntity>> response = new ServiceResponse<List<ResutEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindAll();

            response.Data = entityResponse.Select(c => _mapper.Map<ResutEntity>(c)).ToList();

            response.Success = true;
            response.Message = "Register exist.";
            return response;
        }
        public async Task<ServiceResponse<ResutEntity>> FindByID(long id)
        {
            ServiceResponse<ResutEntity> response = new ServiceResponse<ResutEntity>();
            Entity entityResponse = await _genericRepository.FindByID(id);

            response.Data = _mapper.Map<ResutEntity>(entityResponse);
            response.Success = true;
            response.Message = "Register find.";
            return response;
        }
        public async Task<ServiceResponse<List<ResutEntity>>> FindWithPagedSearch(string query)
        {
            ServiceResponse<List<ResutEntity>> response = new ServiceResponse<List<ResutEntity>>();
            List<Entity> entityResponse = await _genericRepository.FindWithPagedSearch(query);

            response.Data = entityResponse.Select(c => _mapper.Map<ResutEntity>(c)).ToList();
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