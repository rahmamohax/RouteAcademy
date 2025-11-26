

using E_Commerce.Domain.Contracts;
using StackExchange.Redis;

namespace E_Commerce.Presistence.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDatabase _database;
        public CacheRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<string?> GetAsync(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.IsNullOrEmpty ? null : value.ToString();
        }

        public async Task SetAsync(string key, string value, TimeSpan expirty)
        {
           await _database.StringSetAsync(key, value, expirty);
        }
    }
}
