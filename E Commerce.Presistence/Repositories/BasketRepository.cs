using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.BasketModule;
using E_Commerce.Presistence.Data.DbContexts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Presistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();   
        }
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan duration = default)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            var isCreated = await _database.StringSetAsync(basket.Id, jsonBasket, (duration == default)? TimeSpan.FromDays(7) : duration);

            if(isCreated)
            {
                return await GetBasketAsync(basket.Id);
            }
            return null;
        }

        public async Task<bool> DeleteBasketAsync(string id) => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            if(basket.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(basket!);
        }
    }
}
