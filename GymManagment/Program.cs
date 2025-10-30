using GymMangBLL;
using GymMangBLL.Services.Classes;
using GymMangBLL.Services.Interfaces;
using GymMangDAL.Data.Contexts;
using GymMangDAL.Data.DataSeed;
using GymMangDAL.Repositories.Classes;
using GymMangDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GymManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();

            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();
            builder.Services.AddScoped<ISessionService, SessionService>();


            builder.Services.AddAutoMapper(x => x.AddProfile(new Mappingprofiles()));


            var app = builder.Build();

            #region Seeding Data
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations(); //Get Only Pending migrations
            if (pendingMigrations?.Any() ?? false)
                dbContext.Database.Migrate();

            GymDbContectSeeding.DataSeed(dbContext);
            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int?}");

            app.Run();
        }
    }
}
