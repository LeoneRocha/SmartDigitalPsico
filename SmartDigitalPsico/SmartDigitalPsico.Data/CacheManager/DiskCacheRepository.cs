using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Utilities;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.CacheManager
{
    public class DiskCacheRepository : IDiskCacheRepository
    {
        private readonly IRepositoryFileDisk _repositoryFileDisk;
        private readonly CacheConfigurationVO _cacheConfig;

        public DiskCacheRepository(IRepositoryFileDisk repositoryFileDisk, IOptions<CacheConfigurationVO> cacheConfig)
        {
            _repositoryFileDisk = repositoryFileDisk;
            _cacheConfig = cacheConfig.Value;

        }

        public bool Remove(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(string cacheKey)
        {
            bool result = false;
            try
            {
                string filename = string.Concat(cacheKey, _cacheConfig.ExtensionCache);

                var criteriaFind = new FileData() { FilePath = _cacheConfig.PathCache, FileName = filename };

                await _repositoryFileDisk.Delete(criteriaFind);

                result = true;
            }
            catch (Exception)
            {

            }

            return result;
        }

        public bool Set<T>(string cacheKey, T value)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetAsync<T>(string cacheKey, T value)
        {
            bool result = false;
            try
            {
                string filename = string.Concat(cacheKey, _cacheConfig.ExtensionCache);

                var criteriaFind = new FileData() { FilePath = _cacheConfig.PathCache, FileName = filename };

                bool exists = _repositoryFileDisk.Exists(criteriaFind);

                if (exists)
                {
                    await _repositoryFileDisk.Delete(criteriaFind);
                }

                //Gerando cache 
                string jsonString =   JsonSerializer.Serialize(value);
                byte[] bytesString = Encoding.UTF8.GetBytes(jsonString);
                
                string pathSaveCache = Path.Combine(Directory.GetCurrentDirectory(), _cacheConfig.PathCache); ;

                var fileDataSave = new FileData()
                {
                    FilePath = pathSaveCache,
                    FileName = filename,
                    FolderDestination = pathSaveCache,
                    FileData = bytesString
                };

                result = await _repositoryFileDisk.Save(fileDataSave);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyValuePair<bool, T>> TryGetAsync<T>(string cacheKey) where T : new()
        {
            bool result = false;
            string filename = string.Concat(cacheKey, _cacheConfig.ExtensionCache);

            var criteriaFind = new FileData() { FilePath = _cacheConfig.PathCache, FileName = filename };

            bool exists = _repositoryFileDisk.Exists(criteriaFind);

            if (exists)
            {
                byte[]? fileCacheByte = await _repositoryFileDisk.Get(criteriaFind);

                if (fileCacheByte != null)
                {
                    // Ler bytes e transformar em String json
                    string contentString = Encoding.UTF8.GetString(fileCacheByte, 0, fileCacheByte.Length);

                    T? resultCache = JsonSerializer.Deserialize<T>(contentString);
                    result = true;
                    return new KeyValuePair<bool, T>(result, resultCache);
                }
            }
            return new KeyValuePair<bool, T>(result, new());
        }
    }
}
