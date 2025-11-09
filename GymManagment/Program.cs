using GymMangBLL;
using GymMangBLL.Services.Attachments;
using GymMangBLL.Services.Classes;
using GymMangBLL.Services.Interfaces;
using GymMangDAL.Data.Contexts;
using GymMangDAL.Data.DataSeed;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Classes;
using GymMangDAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<GymDbContext>();

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Acoount/Login";
                opt.AccessDeniedPath = "/Account/AccessDenied";
            });

            builder.Services.AddAutoMapper(x => x.AddProfile(new Mappingprofiles()));


            var app = builder.Build();

            #region Seeding Data
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();

            var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations(); //Get Only Pending migrations
            if (pendingMigrations?.Any() ?? false)
                dbContext.Database.Migrate();

            GymDbContextSeeding.DataSeed(dbContext);
            IdentityDbContextSeeding.SeedData(RoleManager, UserManager);
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=account}/{action=login}/{id:int?}");

            app.Run();
        }
    }
}
