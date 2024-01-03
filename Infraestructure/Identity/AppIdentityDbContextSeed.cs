using System.Text.Json;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infraestructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Luis Alonzo",
                        FirstName = "Luis",
                        LastName = "Alonzo",
                        Email = "luisA@test.com",
                        UserName = "luisA@test.com",
                    },
                    new AppUser
                    {
                        DisplayName = "Andder",
                        FirstName = "Andder",
                        LastName = "Frias",
                        Email = "andder@test.com",
                        UserName = "andder@test.com",
                    },
                    new AppUser
                    {
                        DisplayName = "Alejandra",
                        FirstName = "Alejandra",
                        LastName = "Wolf",
                        Email = "alewolf@test.com",
                        UserName = "alewolf@test.com",
                    },
                    new AppUser
                    {
                        DisplayName = "Admin",
                        FirstName = "Andder",
                        LastName = "Frias",
                        Email = "admin@test.com",
                        UserName = "admin@test.com",
                    }
                };

                var roles = new List<AppRole>
                {
                    new AppRole {Name = "Admin"},
                    new AppRole {Name = "Member"},
                    new AppRole {Name = "User"},
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "User");
                    if (user.Email == "admin@test.com") await userManager.AddToRoleAsync(user, "Admin");
                    if (user.Email == "andder@test.com") await userManager.AddToRoleAsync(user, "Member");
                    if (user.Email == "alewolf@test.com") await userManager.AddToRoleAsync(user, "Member");
                }
            }
        }
    }
}