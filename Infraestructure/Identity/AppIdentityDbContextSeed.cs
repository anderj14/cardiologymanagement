using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infraestructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Andder",
                    FirstName = "Andder",
                    LastName = "Frias",
                    Email = "annder@text.com",
                    UserName = "annder@text"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}