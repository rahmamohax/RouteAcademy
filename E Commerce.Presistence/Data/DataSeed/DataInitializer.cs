using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.OrderModule;
using E_Commerce.Domain.Entities.ProductModule;
using E_Commerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Presistence.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly StoreDbContext _dbContext;

        public DataInitializer(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
            try
            {
                bool hasProducts = await _dbContext.Products.AnyAsync();
                bool hasBrands = await _dbContext.ProductBrands.AnyAsync();
                bool hasTypes = await _dbContext.ProductTypes.AnyAsync();
                bool hasDeliveryMethods = await _dbContext.Set<DeliveryMethod>().AnyAsync();
                if (hasProducts && hasBrands && hasTypes && hasDeliveryMethods) return; 

                if (!hasBrands) await SeedDataFromJsonAsync<ProductBrand, int>("brands.json", _dbContext.ProductBrands);
                if (!hasTypes) await SeedDataFromJsonAsync<ProductType, int>("types.json", _dbContext.ProductTypes);
               await _dbContext.SaveChangesAsync();

                if (!hasProducts) await SeedDataFromJsonAsync<Product, int>("products.json", _dbContext.Products);

                if (!hasDeliveryMethods) 
                    await SeedDataFromJsonAsync<DeliveryMethod, int>("delivery.json", _dbContext.Set<DeliveryMethod>());
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data Seeding Failed : " + ex);
            }
        }

        private async Task SeedDataFromJsonAsync<T, TKey>(string fileName, DbSet<T> dbset) where T : BaseEntity<TKey>
        {
            //C:\Users\rhmar\GitHub\Route\API\E-CommerceSolution\E Commerce.Presistence\Data\DataSeed\JSONFiles\brands.json
            string filePath = @"..\E Commerce.Presistence\Data\DataSeed\JSONFiles\" + fileName;
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} does not Exist");

            try
            {
                using var dataStream = File.OpenRead(filePath);

                var data = await JsonSerializer.DeserializeAsync<List<T>>(dataStream, new JsonSerializerOptions() {
                    PropertyNameCaseInsensitive = true
                });

                if (data != null) 
                    dbset.AddRange(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While Reading Json File : " + ex);
            }

        }
    }
}
