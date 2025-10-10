using GymMangDAL.Data.Contexts;
using GymMangDAL.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymMangDAL.Data.DataSeed
{
    public static class GymDbContectSeeding
    {
        public static bool DataSeed(GymDbContext dbContext) 
        {
            try
            {
                var hasPlans = dbContext.Plans.Any();
                var hasCategories = dbContext.Categories.Any();
                if (hasPlans && hasCategories) return false;
                if (!hasPlans)
                {
                    var plans = LoadDataFromJsonFile<Plan>("plans.json");
                    if (plans.Any())
                        dbContext.Plans.AddRange(plans);
                }

                if (!hasCategories)
                {
                    var categories = LoadDataFromJsonFile<Category>("categories.json");
                    if (categories.Any())
                        dbContext.Categories.AddRange(categories);
                }

                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Seeding Failed: " + ex);
                return false;
            }

        }

        private static List<T> LoadDataFromJsonFile<T>(string jsonFile)
        {
            //C:\Users\rhmar\GitHub\Route\MVC\GymManagment\GymManagment\wwwroot\Files\plans.json
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", jsonFile);
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            string data = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<T>>(data, options) ?? new List<T>();
        }
    }
}
