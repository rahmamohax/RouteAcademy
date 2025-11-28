using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Presistence.IdentityData.DataSeed
{
    public class IdentityDataInitializer : IDataInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<IdentityDataInitializer> _logger;

        public IdentityDataInitializer(UserManager<ApplicationUser> userManager,
                                        RoleManager<IdentityRole> roleManager,
                                        ILogger<IdentityDataInitializer> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public async Task InitializeAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                   await _roleManager.CreateAsync(new IdentityRole("Admin"));
                   await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }
                if (!_userManager.Users.Any())
                {
                    var user1 = new ApplicationUser()
                    {
                        DisplayName = "Mohamed Tarek",
                        UserName = "MohamedTarek",
                        Email = "mohamed@gmail.com",
                        PhoneNumber = "1234567890"
                    };
                    var user2 = new ApplicationUser()
                    {
                        DisplayName = "Salma Tarek",
                        UserName = "SalmaTarek",
                        Email = "salma@gmail.com",
                        PhoneNumber = "1234567880"
                    };
                    await _userManager.CreateAsync(user1, "P@ssw0rd");
                    await _userManager.AddToRoleAsync(user1, "Admin");

                    await _userManager.CreateAsync(user2, "P@ssw0rd");
                    await _userManager.AddToRoleAsync(user2, "SuperAdmin");
                }
            }
            catch (Exception)
            {
                _logger.LogError("Error While Seeding Identity Data");
            }
        }
    }
}
