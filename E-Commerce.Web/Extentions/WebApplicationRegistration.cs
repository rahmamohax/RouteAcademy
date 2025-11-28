using E_Commerce.Domain.Contracts;
using E_Commerce.Presistence.Data.DbContexts;
using E_Commerce.Presistence.IdentityData.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.Web.Extentions
{
    public static class WebApplicationRegistration
    {
        public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            var pending = await dbContextService.Database.GetPendingMigrationsAsync();
            if (pending.Any())
                await dbContextService.Database.MigrateAsync();

            return app;
        }
        public static async Task<WebApplication> MigrateIdentityDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<StoreIdentityDbContext>();
            var pending = await dbContextService.Database.GetPendingMigrationsAsync();
            if (pending.Any())
                await dbContextService.Database.MigrateAsync();

            return app;
        }

        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DataInitailizer = scope.ServiceProvider.GetRequiredKeyedService<IDataInitializer>("Default");
            await DataInitailizer.InitializeAsync();

            return app;
        }

        public static async Task<WebApplication> SeedIdentityDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DataInitailizer = scope.ServiceProvider.GetRequiredKeyedService<IDataInitializer>("Identity");
            await DataInitailizer.InitializeAsync();

            return app;
        }

    }
}
