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

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);
            if(user == null)
            {
                user = new AppUser
                {
                    FullName = "Enes Yilmaz",
                    UserName = adminUser,
                    Email = "enesyilmaz.ey3@gmail.com",
                    PhoneNumber = "8978235111"

                };

                await userManager.CreateAsync(user, adminPassword);
            }
        }

    }
}
