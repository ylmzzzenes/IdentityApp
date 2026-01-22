using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static  async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(adminUser);
            if(user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = "enesyilmaz.ey3qgmail.com",
                    PhoneNumber = "8978235111",

                };

                await userManager.CreateAsync(user, adminPassword);
            }
        }

    }
}
