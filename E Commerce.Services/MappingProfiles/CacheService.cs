using E_Commerce.Domain.Contracts;
using E_Commerce.Service_Abstraction;
using System.Text.Json;

namespace E_Commerce.Services.MappingProfiles
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            this._cacheRepository = cacheRepository;
        }
        public async Task<string?> GetAsync(string key)
        {
            return await _cacheRepository.GetAsync(key);
        }

        public async Task SetAsync(string key, object value, TimeSpan expirty)
        {
            var jsonVal = JsonSerializer.Serialize(value, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await _cacheRepository.SetAsync(key, jsonVal, expirty);
        }
    }
}
