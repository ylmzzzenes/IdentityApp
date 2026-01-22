using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityApp"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{Action=Index}/{id?}"
    );
IdentitySeedData.IdentityTestUser(app);

app.Run();
