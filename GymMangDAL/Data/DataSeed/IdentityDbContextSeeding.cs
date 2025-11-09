using GymMangDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Data.DataSeed
{
    public static class IdentityDbContextSeeding
    {
        public static bool SeedData(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
			try
			{
                var hasUsers = userManager.Users.Any();
                var hasRoles = roleManager.Roles.Any();
                if (hasUsers && hasRoles) return false;
                
                if (!hasRoles)
                {
                    var Roles = new List<IdentityRole>()
                    {
                        new(){Name = "SuperAdmin"},
                        new(){Name = "Admin"}
                    };

                    foreach (var Role in Roles)
                    {
                        if(!roleManager.RoleExistsAsync(Role.Name!).Result)
                        {
                            var roleResult = roleManager.CreateAsync(Role).Result;
                            if (!roleResult.Succeeded)
                            {
                                throw new Exception($"Failed to create role {Role.Name}: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                            }
                        }
                    }
                }

                if (!hasUsers)
                {
                    var mainAdmin = new ApplicationUser()
                    {
                        FirstName = "Rahma",
                        LastName = "Mohamed",
                        UserName = "rahmaa",
                        Email = "rahma22@gmail.com",
                        PhoneNumber = "1234567890",
                        EmailConfirmed = true
                    };
                    var createResult = userManager.CreateAsync(mainAdmin, "Admin@1234").Result;
                    if (!createResult.Succeeded)
                    {
                        throw new Exception($"Failed to create main admin user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                    }
                    
                    var roleResult = userManager.AddToRoleAsync(mainAdmin, "SuperAdmin").Result;
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add SuperAdmin role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }

                    var Admin = new ApplicationUser()
                    {
                        FirstName = "Mohamed",
                        LastName = "Omar",
                        UserName = "mohamed",
                        Email = "mohamedomar@gmail.com",
                        PhoneNumber = "1234567890",
                        EmailConfirmed = true
                    };
                    createResult = userManager.CreateAsync(Admin, "Admin@1234").Result;
                    if (!createResult.Succeeded)
                    {
                        throw new Exception($"Failed to create admin user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                    }
                    
                    roleResult = userManager.AddToRoleAsync(Admin, "Admin").Result;
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add Admin role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }

                return true;
			}
			catch (Exception ex)
			{
                Console.WriteLine($"Seeding Failed: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
			}
        }
    }
}
